using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SoftUniLoginTest
{
    [TestClass]
    public class SoftUniLoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            this.driver = new FirefoxDriver();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        
        [TestMethod]
        public void TestLogin_ValidCredentials_ShouldLoginCorrectly()
        {
            driver.Navigate().GoToUrl("https://softuni.bg");

            IWebElement loginLink = this.driver.FindElement(
                By.XPath("/html/body/div[2]/div[1]/header/nav/div[2]/ul/li[3]/span/a"));
            loginLink.Click();

            IWebElement loginUsernameField = this.driver.FindElement(By.Id("LoginUserName"));
            string validUsername = "testtest";
            loginUsernameField.SendKeys(validUsername);

            IWebElement loginPasswordField = this.driver.FindElement(By.Id("LoginPassword"));
            String validPassword = "testtest";
            loginPasswordField.SendKeys(validPassword);

            IWebElement loginButton = this.driver.FindElement(
                By.XPath("/html/body/div[3]/div[2]/div/div[1]/form/input[2]"));
            loginButton.Click();

            Assert.AreEqual("https://softuni.bg/users/profile/show", this.driver.Url);

            IWebElement actualFullName = this.driver.FindElement(
                By.XPath("/html/body/div[3]/div[2]/div[1]/div/div[1]/div/div/div[1]/div/div[2]/h2/strong"));
            string expectedFullName = "testtest" + " (" + validUsername + ")";

            Assert.AreEqual(expectedFullName, actualFullName.Text);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.driver.Close();
        }
    }
}
