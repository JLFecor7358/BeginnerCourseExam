// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Collections.Generic;

namespace SeleniumCore
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

        }

        [Test]
        public void TestMethod()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            Assert.IsTrue(_driver.Title.Contains("Google"));
            
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();

        }
    }
}
