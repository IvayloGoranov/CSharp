using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

public class SelectDemo
{
    public static void Main()
    {
        using (IWebDriver driver = new FirefoxDriver())
        {
            driver.Url = @"http://demo.loway.ch/queuemetrics-livedemo/autenticazione.jsp";

            IWebElement loginUsernameField = driver.FindElement(By.Id("AUTH_logon"));
            string validUsername = "demo";
            loginUsernameField.SendKeys(validUsername);

            IWebElement loginPasswordField = driver.FindElement(By.Id("AUTH_password"));
            String validPassword = "demo";
            loginPasswordField.SendKeys(validPassword);

            IWebElement loginButton = driver.FindElement(
                By.XPath("//div[@id='xCorpo']/center/table/tbody/tr[4]/td[2]/input"));
            loginButton.Click();

            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("CODA_F_agenteFiltro")));
            selectElement.SelectByText("Mara (301)");


            Console.WriteLine(selectElement.SelectedOption.Text);
        }
    }
}
