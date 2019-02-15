# VSTSDumpTestResults
A small C# program that dumps all testresults that are in one VSTS tenant as json to disk.
It uses VSTS Rest API to walk through Projects, TestPlans, TestSuites and Testresults.

#Configuration (Program.cs)
Change the tenant name of VSTS
**public const string DevOpsTenant = "https://dev.azure.com/tenant/";**
A user that has the necessary permissions to access test data
**public const string User = "user@something.com";
A generated PAT (Personal Access Token) of VSTS see https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops
**public const string Personalaccesstoken = "enterpathere";
Output Folder
**public const string OutputFile = @"C:\output.json";
