﻿// using System;
// using System.Threading;
// using System.Collections.ObjectModel;
// using NUnit.Framework;
// using OpenQA.Selenium.Appium;
// using OpenQA.Selenium.Appium.iOS;
// using OpenQA.Selenium.Support.UI;

// namespace ios
// {
// [TestFixture("parallel", "iphone-7")]
// [TestFixture("parallel", "iphone-8-plus")]
// [Parallelizable(ParallelScope.Fixtures)]
// public class ParallelTest : BrowserStackNUnitTest
// {
// public ParallelTest(string profile, string device) : base(profile, device) {}

// [Test]
//        [Obsolete]
//        public void textVerificationTest()
// {
// IOSElement textButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Button")));
// textButton.Click();

// IOSElement textInput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Input")));
// textInput.SendKeys("hello@browserstack.com"+"\n");

// IOSElement textOutput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Output")));
// Assert.AreEqual(textOutput.Text,"hello@browserstack.com");
// }
// }
// }
