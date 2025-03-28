using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace AppiumSpecFlowProject1.Utilities
{
    public class AppiumUtilities
    {
        private AppiumLocalService _appiumLocalService;
        private AndroidDriver _androidDriver;

        public AppiumUtilities(AppiumLocalService appiumLocalService, AndroidDriver androidDriver)
        {
            this._appiumLocalService = appiumLocalService;
            _androidDriver = androidDriver;
        }

        public AndroidDriver InitializeAndroidNativeApp()
        {
            // Use a relative path to make it work in GitHub Actions
            var appPath = Path.Combine(Directory.GetCurrentDirectory(), "ApiDemos-debug.apk");

            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");
            var driverOptions = new AppiumOptions();
            driverOptions.AutomationName = AutomationName.AndroidUIAutomator2; // Use the AutomationName property
            driverOptions.PlatformName = "Android"; // Use the PlatformName property
            driverOptions.DeviceName = "custom_emulator"; // Use the DeviceName property
            driverOptions.App = appPath; // Use the App property
            driverOptions.NoReset = true; // Use the NoReset property

            return new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
        }

        public AndroidDriver InitializeAndroidWebApp()
        {
            var appPath = Path.Combine(Directory.GetCurrentDirectory(), "ApiDemos-debug.apk");

            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");
            var driverOptions = new AppiumOptions();
            driverOptions.AutomationName = AutomationName.AndroidUIAutomator2; // Use the AutomationName property
            driverOptions.PlatformName = "Android"; // Use the PlatformName property
            driverOptions.DeviceName = "custom_emulator"; // Use the DeviceName property
            driverOptions.App = appPath; // Use the App property
            driverOptions.NoReset = true; // Use the NoReset property

            AndroidDriver androidDriver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

            List<string> AllContexts = new List<string>();
            foreach (var context in androidDriver.Contexts)
            {
                Console.WriteLine(context);
            }
            var driv = androidDriver.Contexts.First(x => x.Contains("WEBVIEW_io.appium.android.apis"));

            androidDriver.Context = driv;
            return androidDriver;
        }

        public AppiumLocalService StartAppiumLocalService()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            if (!_appiumLocalService.IsRunning)
            {
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }

        public AppiumLocalService StartAppiumLocalService(int portNumber)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingPort(portNumber).Build();
            if (!_appiumLocalService.IsRunning)
            {
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }

        public void CloseAppiumServer()
        {
            _appiumLocalService.Dispose();
        }
    }
}
