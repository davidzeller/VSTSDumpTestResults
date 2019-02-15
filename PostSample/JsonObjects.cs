using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSDumpTestResults.JsonObjects.TestResults
{
    public class AssignedTo
    {
        public string displayName { get; set; }
        public string id { get; set; }
    }

    public class Configuration
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class LastTestRun
    {
        public string id { get; set; }
    }

    public class LastResult
    {
        public string id { get; set; }
    }

    public class TestCase
    {
        public string id { get; set; }
    }

    public class WorkItem
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class WorkItemProperty
    {
        public WorkItem workItem { get; set; }
    }

    public class RunBy
    {
        public string displayName { get; set; }
        public string id { get; set; }
    }

    public class LastResultDetails
    {
        public int duration { get; set; }
        public DateTime dateCompleted { get; set; }
        public RunBy runBy { get; set; }
    }

    public class TestResult
    {
        public int id { get; set; }
        public string url { get; set; }
        public AssignedTo assignedTo { get; set; }
        public bool automated { get; set; }
        public Configuration configuration { get; set; }
        public LastTestRun lastTestRun { get; set; }
        public LastResult lastResult { get; set; }
        public string outcome { get; set; }
        public string state { get; set; }
        public string lastResultState { get; set; }
        public TestCase testCase { get; set; }
        public List<WorkItemProperty> workItemProperties { get; set; }
        public LastResultDetails lastResultDetails { get; set; }
        public string lastRunBuildNumber { get; set; }
    }

    public class TestResultList
    {
        public List<TestResult> value { get; set; }
        public int count { get; set; }
    }
}

namespace VSTSDumpTestResults.JsonObjects.Projects
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public int revision { get; set; }
        public string visibility { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string description { get; set; }
    }

    public class ProjectList
    {
        public int count { get; set; }
        public List<Project> value { get; set; }
    }
}

namespace VSTSDumpTestResults.JsonObjects.TestSuite
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public string visibility { get; set; }
        public DateTime lastUpdateTime { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Avatar avatar { get; set; }
    }

    public class LastUpdatedBy
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class Plan
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class TestCases
    {
        public string href { get; set; }
    }

    public class TestPoints
    {
        public string href { get; set; }
    }

    public class Links2
    {
        public Self _self { get; set; }
        public TestCases testCases { get; set; }
        public TestPoints testPoints { get; set; }
    }

    public class DefaultConfiguration
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class TestSuite
    {
        public int id { get; set; }
        public int revision { get; set; }
        public Project project { get; set; }
        public LastUpdatedBy lastUpdatedBy { get; set; }
        public DateTime lastUpdatedDate { get; set; }
        public Plan plan { get; set; }
        public Links2 _links { get; set; }
        public string suiteType { get; set; }
        public string name { get; set; }
        public bool inheritDefaultConfigurations { get; set; }
        public List<DefaultConfiguration> defaultConfigurations { get; set; }
    }

    public class TestSuiteList
    {
        public List<TestSuite> value { get; set; }
        public int count { get; set; }
    }
}

namespace VSTSDumpTestResults.JsonObjects.TestPlan
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string visibility { get; set; }
        public DateTime lastUpdateTime { get; set; }
    }

    public class RootSuite
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class ClientUrl
    {
        public string href { get; set; }
    }

    public class RootSuite2
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self _self { get; set; }
        public ClientUrl clientUrl { get; set; }
        public RootSuite2 rootSuite { get; set; }
    }

    public class TestPlan
    {
        public int id { get; set; }
        public Project project { get; set; }
        public RootSuite rootSuite { get; set; }
        public Links _links { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string areaPath { get; set; }
        public string iteration { get; set; }
        public object owner { get; set; }
        public string state { get; set; }
    }

    public class TestPlanList
    {
        public List<TestPlan> value { get; set; }
        public int count { get; set; }
    }
}
