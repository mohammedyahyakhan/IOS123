// using NUnit.Framework;
// using NUnit.Framework.Interfaces;
// using RelevantCodes.ExtentReports;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace ios
// {

// [TestFixture]

// public class Basic reports

// {

// //Instance of extents reports
//        public ExtentReports extent;
//        public ExtentTest test;



// [OneTimeSetUp]
//        public void StartReport()

// {

// //To obtain the current solution path/project path
//            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
//            string projectPath = new Uri(actualPath).LocalPath;

// //Append the html report file to current project path
//            string reportPath = projectPath + "Reports\\TestRunReport.html";

// //Boolean value for replacing existing report
//            extent = new ExtentReports(reportPath, true);

// //Add QA system info to html report
//            extent.AddSystemInfo("Host Name", "iOS Execution").AddSystemInfo("Environment", "QA").AddSystemInfo("Username", "iOSExecution");

// //Adding config.xml file
//            extent.LoadConfig(projectPath + "Extent-Config.xml"); //Get the config.xml file from http://extentreports.com

// }


// [TearDown]

// public void AfterClass()
//         {
//            //StackTrace details for failed Test cases
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
//            var errorMessage = TestContext.CurrentContext.Result.Message;

// if (status == TestStatus.Failed)
//            {
//                test.Log(LogStatus.Fail, status + errorMessage);
//            }

// //End test report
//            extent.EndTest(test);
//        }



// [OneTimeTearDown]
//        public void EndReport()
//        {
//            //End Report
//            extent.Flush();
//            extent.Close();
//         }

// }

// }
