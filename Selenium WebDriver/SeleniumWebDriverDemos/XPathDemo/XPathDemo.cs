using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class XPathDemo
{
    public static void Main()
    {
        using (IWebDriver driver = new FirefoxDriver())
        {
            driver.Url = @"http://www.tutorialspoint.com/html/html_tables.htm";
            IWebElement element = driver.FindElement(By.XPath("//td[contains(text(), 'Shabbir')]/following-sibling::td[1]"));
            Console.WriteLine(element.Text);
        }
    }
}
