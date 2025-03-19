using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AppiumSpecFlowProject1.Hooks
{
    [Binding]
    public partial class SpecInitialize : Base
    {
        [BeforeScenario]
        public void TestInitializeTest()
        {
            try
            {
                Console.WriteLine("Initializing Appium for Scenario...");
                AndroidContext = StartAppiumServerForHybrid();

                if (ScenarioContext.Current.ContainsKey("androidContext"))
                {
                    ScenarioContext.Current["androidContext"] = AndroidContext;
                }
                else
                {
                    ScenarioContext.Current.Add("androidContext", AndroidContext);
                }

                Console.WriteLine("Appium Initialized for Scenario.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Initializing Appium: {ex.Message}");
                throw;
            }
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (AppiumServiceContext != null)
            {
                Console.WriteLine("Stopping Appium Server...");
                AppiumServiceContext.Dispose();
                Console.WriteLine("Appium Server Stopped.");
            }
        }
    }
}
