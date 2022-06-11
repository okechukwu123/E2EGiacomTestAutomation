namespace E2EGiacomTestAutomation.Utilities.Helpers
{
    using System;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using E2EGiacomTestAutomation.Utilities.Extensions;
    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    public static class Wait
    {
        /// <summary>
        /// Wait for jQuery and Javascript to load
        /// </summary>
        public static void WaitForJsJq()
        {
            WebDriverWait waitDriver = SeleniumExecutor.WaitDriver();

            try
            {
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return document.readyState == 'complete'"));
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return jQuery.active == 0"));
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Wait until element is present in DOM
        /// </summary>
        /// <param name="elementLocator">By</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementPresence(By elementLocator, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(d =>
                {
                    try
                    {
                        d.FindElement(elementLocator);
                        return true;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' could not be found within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be displayed
        /// </summary>
        /// <param name="elementLocator">By</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsDisplayed(By elementLocator, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't visible within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be displayed
        /// </summary>
        /// <param name="element">WebElement</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsDisplayed(IWebElement element, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(d => element.Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element wasn't visible within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be enabled
        /// </summary>
        /// <param name="elementLocator">By</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsEnabled(By elementLocator, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(d => d.FindElement(elementLocator).Enabled);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't enabled within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be enabled
        /// </summary>
        /// <param name="element">WebElement</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsEnabled(IWebElement element, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(d => element.Enabled);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element wasn't enabled within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be clickable
        /// </summary>
        /// <param name="elementLocator">By</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsClickable(By elementLocator, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't clickable within specified timeout limit", e);
            }
        }

        /// <summary>
        /// Wait for element to be clickable
        /// </summary>
        /// <param name="element">WebElement</param>
        /// <param name="customTimeout">TimeSpan</param>
        public static void UntilElementIsClickable(IWebElement element, TimeSpan? customTimeout = null)
        {
            try
            {
                SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element wasn't clickable within specified timeout limit", e);
            }
        }
    }
}