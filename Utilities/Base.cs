using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;

namespace AppiumSpecFlowProject1.Utilities
{
    public class Base
    {
        public AppiumLocalService AppiumServiceContext;
        public static AndroidDriver AndroidContext;
        private AppiumUtilities _appiumUtilities;

        public Base()
        {
            _appiumUtilities = new AppiumUtilities(AppiumServiceContext, AndroidContext);
        }

        public AndroidDriver StartAppiumServerForHybrid()
        {
            AppiumServiceContext = _appiumUtilities.StartAppiumLocalService();
            AndroidContext = _appiumUtilities.InitializeAndroidNativeApp();
            return AndroidContext;
        }
    }
}
