using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

public class TestUtils
{
    public TestUtils(IWebDriver driver, string baseUrl, int timeOut)
    {
        this.Browser = driver;
        this.BaseUrl = baseUrl;
        this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
        this.TimeOut = timeOut;
    }

    public IWebDriver Browser { get; set; }

    public StringBuilder VerificationErrors { get; set; }

    public string BaseUrl { get; set; }

    public WebDriverWait Wait { get; set; }

    public IWebElement CurrentElement { get; set; }

    public int TimeOut { get; set; }

    public IWebElement GetElement(By by)
    {
        IWebElement result = null;
        try
        {
            result = this.Wait.Until(x => x.FindElement(by));
        }
        catch (TimeoutException ex)
        {
            throw new NoSuchElementException("The specified element was not found within the specified time frame", ex);
        }

        return result;
    }

    public bool IsElementPresent(By by)
    {
        try
        {
            this.Browser.FindElement(by);
            return true;
        }
        catch (NoSuchElementException ex)
        {
            return false;
        }
    }

    public void WaitForElementPresent(By by)
    {
        this.GetElement(by);
    }

    public void WaitForElementNotPresent(By by)
    {
        try
        {
            this.GetElement(by);
            throw new ElementStillVisibleException("The specified element is still visible.");
        }
        catch (NoSuchElementException ex)
        {
        }
    }

    public void WaitForChecked(By by)
    {
        IWebElement currentElement = this.GetElement(by);
        bool isSelected = currentElement.Selected;

        if (!isSelected)
        {
            throw new NotCheckedException("The specified element was not checked.");
        }
    }

    public void WaitForNotChecked(By by)
    {
        IWebElement currentElement = this.GetElement(by);
        bool isSelected = currentElement.Selected;

        if (isSelected)
        {
            throw new StillCheckedException("The specified element is still checked");
        }
    }

    public void WaitForText(By by, string textToFind)
    {
        IWebElement currentElement = this.GetElement(by);
        string elementText = currentElement.Text;

        if (!textToFind.Equals(elementText))
        {
            throw new TextNotFoundException("The specified text element wa snot found.");
        }
    }
}