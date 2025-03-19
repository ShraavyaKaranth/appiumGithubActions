using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Utilities;
using NUnit.Framework;

namespace AppiumSpecFlowProject1.Hooks
{
    [TestFixture]
    public class TestInitialize : Base
    {
        [SetUp]
        public void TestInitializeTest()
        {
            try
            {
                Console.WriteLine("Starting Appium Server...");
                AndroidContext = StartAppiumServerForHybrid();
                Console.WriteLine("Appium Server Started Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Starting Appium: {ex.Message}");
                throw;
            }
        }

        [TearDown]
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
