using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VSTSDumpTestResults
{
    class Program
    {
        public const string DevOpsTenant = "https://dev.azure.com/tenant/";
        public const string User = "user@something.com";
        public const string Personalaccesstoken = "enterpathere";
        public const string OutputFile = @"C:\output.json";

        static void Main(string[] args)
        {  
            var erg = new List<JsonObjects.TestResults.TestResult>();

            foreach(var proj in GetProjects())
            {
                foreach (var plan in GetTestPlans(proj.name))
                {
                    foreach(var suite in GetTestSuites(proj.name, plan.id))
                    {
                        erg.AddRange(GetTestResultsAsJson(proj.name, plan.id, suite.id));
                    }
                }
            }

            System.IO.File.WriteAllText(OutputFile, JsonConvert.SerializeObject(erg));
            System.Console.ReadLine();
        }

        public static List<JsonObjects.TestResults.TestResult> GetTestResultsAsJson(string projname, int planid, int suiteid)
        {
            string uri = DevOpsTenant + projname + "/_apis/test/Plans/" + planid + "/Suites/" + suiteid + "/points?api-version=5.0";
            return GetDevOpsObjectFromUri<JsonObjects.TestResults.TestResultList>(uri).Result.value;
        }

        public static List<JsonObjects.Projects.Project> GetProjects()
        {
            string uri = DevOpsTenant + "/_apis/projects";
            return GetDevOpsObjectFromUri<JsonObjects.Projects.ProjectList>(uri).Result.value;
        }

        public static List<JsonObjects.TestPlan.TestPlan> GetTestPlans(string projname)
        {
            string uri = DevOpsTenant + projname + "/_apis/testplan/plans?api-version=5.0-preview.1";
            return GetDevOpsObjectFromUri<JsonObjects.TestPlan.TestPlanList>(uri).Result.value;
        }

        public static List<JsonObjects.TestSuite.TestSuite> GetTestSuites(string projname, int testplanid)
        {
            string uri = DevOpsTenant + projname + "/_apis/testplan/Plans/" + testplanid.ToString() + "/suites?api-version=5.0-preview.1";
            return GetDevOpsObjectFromUri<JsonObjects.TestSuite.TestSuiteList>(uri).Result.value;
        }

        public static async Task<T> GetDevOpsObjectFromUri<T>(string uri) 
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", User, Personalaccesstoken))));
                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return default(T);
        }
    }
}