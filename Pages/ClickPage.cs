using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace AppiumSpecFlowProject1.Pages
{
    public class ClickPage
    {
        private AndroidDriver _driver;

        public ClickPage(AndroidDriver androidDriver)
        {
            this._driver = androidDriver;
            PageFactory.InitElements(androidDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Views\"]")]
        private IWebElement Views { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Radio Group\"]")]
        private IWebElement radio { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.RadioButton[@content-desc=\"Dinner\"]")]
        private IWebElement dinner { get; set; }

        public void ClickViews()
        {
            Console.WriteLine("Clicking 'Views' Element...");
            Views.Click();
        }

        public void HandlingRadioCheckboxes()
        {
            Console.WriteLine("Handling Radio Checkboxes...");

            IList<AppiumElement> elements = _driver.FindElements(MobileBy.ClassName("android.widget.TextView"));
            if (elements.Count < 14)
            {
                Console.WriteLine("Error: Not enough elements found.");
                return;
            }

            var origin = elements[13];
            var target = elements[1];

            var touch = new PointerInputDevice(PointerKind.Touch, "finger");
            var actionBuilder = new ActionBuilder();

            actionBuilder.AddAction(touch.CreatePointerMove(origin, 0, 0, TimeSpan.FromMilliseconds(800)));
            actionBuilder.AddAction(touch.CreatePointerDown(PointerButton.TouchContact));
            actionBuilder.AddAction(touch.CreatePause(TimeSpan.FromMilliseconds(800)));
            actionBuilder.AddAction(touch.CreatePointerMove(target, 0, 0, TimeSpan.FromMilliseconds(800)));
            actionBuilder.AddAction(touch.CreatePointerUp(PointerButton.TouchContact));

            _driver.PerformActions(actionBuilder.ToActionSequenceList());

            Console.WriteLine("Clicking 'Radio Group'...");
            radio.Click();

            Console.WriteLine("Clicking 'Dinner' Radio Button...");
            dinner.Click();
        }
    }
}
