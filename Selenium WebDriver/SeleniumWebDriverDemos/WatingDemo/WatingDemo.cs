using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

public class WaitingDemo
{
    public static void Main()
    {
        //Explicit wait.
        using (IWebDriver driver = new FirefoxDriver())
        {
            driver.Url = @"http://www.tutorialspoint.com/html/html_tables.htm";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>( (d) =>
            {
                return d.FindElement(By.XPath("//td[contains(text(), 'Shabbir')]/following-sibling::td[1]"));
            });

            Console.WriteLine(myDynamicElement.Text);
        }

        //Implicit wait
        //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
    }
}
