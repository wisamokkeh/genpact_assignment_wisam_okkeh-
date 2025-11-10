using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationWiki.Core
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        private const string Url = "https://en.wikipedia.org/wiki/Playwright_(software)";

        private static ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            if (_extent != null)
                return;

            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string reportsDir = Path.Combine(projectRoot, "Reports");

            if (!Directory.Exists(reportsDir))
            {
                Directory.CreateDirectory(reportsDir);
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string reportPath = Path.Combine(reportsDir, $"report_{timestamp}.html");

            var report = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(report);

            Console.WriteLine($"Report created at: {reportPath}");
        }

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(Url);
            Driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TearDown()
        {
            var result = TestContext.CurrentContext.Result;

            if (result.Outcome.Status == TestStatus.Passed)
            {
                _test.Pass("Passed");
            }
            else if (result.Outcome.Status == TestStatus.Failed)
            {
                _test.Fail(result.Message);
            }
            else
            {
                _test.Skip("Test Skipped");
            }


            if (Driver is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extent.Flush();
        }
    }
}
