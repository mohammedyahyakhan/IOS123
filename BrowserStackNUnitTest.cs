// <copyright file="BrowserStackNUnitTest.cs" company="Eastern Bank">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Ios
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using BrowserStack;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    public class BrowserStackNUnitTest
    {
        private protected IOSDriver<IOSElement> Driver;

        private readonly string profile;

        private readonly string device;
        private Local browserStackLocal;

        public BrowserStackNUnitTest(string profile, string device)
        {
            this.profile = profile;
            this.device = device;
        }

        [SetUp]
        [Obsolete]
        public void Init()
        {
            var capability = new DesiredCapabilities();

            if (ConfigurationManager.GetSection("capabilities/" + this.profile) is NameValueCollection caps)
            {
                foreach (var key in caps.AllKeys)
                {
                    capability.SetCapability(key, caps[key]);
                }
            }

            if (ConfigurationManager.GetSection("environments/" + this.device) is NameValueCollection devices)
            {
                foreach (var key in devices.AllKeys)
                {
                    capability.SetCapability(key, devices[key]);
                }
            }

            var username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ?? ConfigurationManager.AppSettings.Get("user");

            var accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ?? ConfigurationManager.AppSettings.Get("key");

            capability.SetCapability("browserstack.user", username);
            capability.SetCapability("browserstack.key", accesskey);

            var appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
            if (appId != null)
            {
                capability.SetCapability("app", appId);
            }

            var browserstackLocalArgs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key", accesskey)
            };
            if ((capability.GetCapability("browserstack.local") != null) && (capability.GetCapability("browserstack.local").ToString() == "true"))
            {
                this.browserStackLocal = new Local();
                this.browserStackLocal.start(browserstackLocalArgs);
            }

            this.Driver = new IOSDriver<IOSElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                this.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [TearDown]
        public void Cleanup()
        {
            this.Driver.Quit();
            this.browserStackLocal?.stop();
        }

        [Obsolete]
        public void Case106370Cleanup()
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("View/Manage Scheduled Transfers")));

            var viewScheduledTransfers = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'View/Manage Scheduled Transfers')]")));
            viewScheduledTransfers.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("Scheduled Transfers")));

            var recurringWeekly = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'Transfer on')]")));
            recurringWeekly.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("Transfer Details")));

            var delete = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'Delete')]")));
            delete.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("Delete This and All Future Transfers")));

            var deleteAllTransfers = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'Delete')]")));
            deleteAllTransfers.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("Delete Transfer?")));

            var yes = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'Delete')]")));
            yes.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("OK")));

            var ok = (RemoteWebElement)new WebDriverWait(this.Driver, TimeSpan.FromMinutes(2)).Until(
            ExpectedConditions.ElementExists(By.XPath("//XCUIElementTypeButton[contains(@name,'Delete')]")));
            ok.Click();
        }
    }
}
