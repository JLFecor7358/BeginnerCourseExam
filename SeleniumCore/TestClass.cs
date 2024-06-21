// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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
        [Category("Smoke Test")]
        public void LoginSauceDemo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            _driver.FindElement(By.Id("login-button")).Submit();
            Assert.That(_driver.FindElement(By.Id("shopping_cart_container")).Displayed);
        }
        [Test]
        [Category("Smoke Test")]
        public void AddToCart()
        {
            LoginSauceDemo();
            _driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Click();
            _driver.FindElement(By.Id("shopping_cart_container")).Click();
            Assert.That((_driver.FindElement(By.Id("item_4_title_link")).Text),Is.EqualTo("Sauce Labs Backpack"));
        }
        [Test]
        [Category("Smoke Test")]
        public void CartCheckout()
        {
            AddToCart();
            _driver.FindElement(By.Id("checkout")).Click();
            _driver.FindElement(By.Id("first-name")).SendKeys("Julio");
            _driver.FindElement(By.Id("last-name")).SendKeys("Lopez");
            _driver.FindElement(By.Id("postal-code")).SendKeys("12345");
            _driver.FindElement(By.Id("continue")).Submit();
            _driver.FindElement(By.Id("finish")).Click();
            Assert.That(_driver.FindElement(By.Id("back-to-products")).Displayed);
        }
        [Test]
        [Category("Smoke Test")]
        public void LogoutSauceDemo()
        {
            LoginSauceDemo();
            _driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            wait.Until(d => _driver.FindElement(By.Id("logout_sidebar_link")).Displayed);
            _driver.FindElement(By.Id("logout_sidebar_link")).Click();
            Assert.That(_driver.FindElement(By.Id("login-button")).Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
