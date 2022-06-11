namespace E2EGiacomTestAutomation.Utilities.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Helpers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class ElementLocatorExtensions
    {
        public static IWebElement GetElement(this By elementLocator)
        {
            return SeleniumExecutor.SearchContext.FindElement(elementLocator);
        }

        public static IWebElement GetElement(this By elementLocator, By parentElement)
        {
            return SeleniumExecutor.SearchContext.FindElement(parentElement).FindElement(elementLocator);
        }

        public static IWebElement GetElement(this By elementLocator, IWebElement parentElement)
        {
            return parentElement.FindElement(elementLocator);
        }

        public static IWebElement GetElementWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementPresence(elementLocator, customTimeout);
            return elementLocator.GetElement();
        }

        public static IWebElement GetElementWithWait(this By elementLocator, By parentElement, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementPresence(parentElement, customTimeout);
            return elementLocator.GetElement(parentElement);
        }

        public static IWebElement GetElementWithWait(this By elementLocator, IWebElement parentElement, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(parentElement, customTimeout);
            return elementLocator.GetElement(parentElement);
        }

        public static IList<IWebElement> GetElements(this By elementLocator)
        {
            return SeleniumExecutor.SearchContext.FindElements(elementLocator);
        }

        public static IList<IWebElement> GetElements(this By elementLocator, By parentElement)
        {
            var parent = parentElement.GetElement();
            return parent.FindElements(elementLocator);
        }

        public static IList<IWebElement> GetElements(this By elementLocator, IWebElement parentElement)
        {
            return parentElement.FindElements(elementLocator);
        }

        public static void Click(this By elementLocator)
        {
            elementLocator.GetElement().Click();
        }

        public static void ClickWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.Click();
        }

        public static void Clear(this By elementLocator)
        {
            elementLocator.GetElement().Clear();
        }

        public static void ClearWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.Clear();
        }

        public static void JsClick(this By elementLocator)
        {
            elementLocator.GetElement().JsClick();
        }

        public static void JsClickWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            elementLocator.GetElementWithWait(customTimeout).JsClick();
        }

        public static void SendKeys(this By elementLocator, string text)
        {
            elementLocator.GetElement().SendKeys(text);
        }

        public static void SendKeysWithWait(this By elementLocator, string text, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.SendKeys(text);
        }

        public static void ClearAndSendKeys(this By elementLocator, string text)
        {
            elementLocator.Clear();
            elementLocator.SendKeys(text);
        }

        public static void ClearAndSendKeysWithWait(this By elementLocator, string text, TimeSpan? customTimeout = null)
        {
            elementLocator.ClearWithWait(customTimeout);
            elementLocator.SendKeysWithWait(text, customTimeout);
        }

        public static string GetAttribute(this By elementLocator, string attribute)
        {
            return elementLocator.GetElement().GetAttribute(attribute);
        }

        public static string GetAttributeWithWait(this By elementLocator, string attribute, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetAttribute(attribute);
        }

        public static string GetCssValue(this By elementLocator, string propertyName)
        {
            return elementLocator.GetElement().GetCssValue(propertyName);
        }

        public static string GetCssValueWithWait(this By elementLocator, string propertyName, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetCssValue(propertyName);
        }

        public static string GetProperty(this By elementLocator, string propertyName)
        {
            return elementLocator.GetElement().GetProperty(propertyName);
        }

        public static string GetPropertyWithWait(this By elementLocator, string propertyName, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetProperty(propertyName);
        }

        public static bool IsDisplayed(this By elementLocator)
        {
            try
            {
                var element = elementLocator.GetElement();
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this By elementLocator, IWebElement parentElement)
        {
            try
            {
                var element = parentElement.FindElement(elementLocator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this By elementLocator, By parentElement)
        {
            try
            {
                var parent = parentElement.GetElement();
                var element = parent.FindElement(elementLocator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayedAfterWait(this By elementLocator)
        {
            try
            {
                Wait.UntilElementIsDisplayed(elementLocator);
                return elementLocator.GetElement().Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static string Text(this By elementLocator)
        {
            return elementLocator.GetElement().Text;
        }

        public static string TextWithWait(this By elementLocator)
        {
            return elementLocator.GetElementWithWait().Text;
        }

        public static string Text(this By elementLocator, IWebElement parentElement)
        {
            return elementLocator.GetElement(parentElement).Text;
        }

        public static string Text(this By elementLocator, By parentElement)
        {
            return elementLocator.GetElement(parentElement).Text;
        }

        public static string TagName(this By elementLocator)
        {
            return elementLocator.GetElement().TagName;
        }

        public static string TagName(this By elementLocator, IWebElement parentElement)
        {
            return elementLocator.GetElement(parentElement).TagName;
        }

        public static string TagName(this By elementLocator, By parentElement)
        {
            return elementLocator.GetElement(parentElement).TagName;
        }

        public static bool IsEnabled(this By elementLocalization)
        {
            return elementLocalization.GetElementWithWait().Enabled;
        }

        public static bool IsSelected(this By elementLocalization)
        {
            return elementLocalization.GetElementWithWait().Selected;
        }

        public static Point Location(this By elementLocator)
        {
            return elementLocator.GetElementWithWait().Location;
        }

        public static Size Size(this By elementLocator)
        {
            return elementLocator.GetElementWithWait().Size;
        }

        public static SelectElement GetSelectElement(this By elementLocator)
        {
            return new SelectElement(elementLocator.GetElementWithWait());
        }

        public static void SelectText(this By elementLocator, string text)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByText(text);
        }

        public static void SelectValue(this By elementLocator, string value)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByValue(value);
        }

        public static void SelectIndex(this By elementLocator, int index)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByIndex(index);
        }

        public static void HoverOverElement(this By elementLocator)
        {
            elementLocator.GetElement().HoverOverElement();
        }

        public static IWebElement GetParentElement(this By elementLocator)
        {
            var element = elementLocator.GetElement();
            return element.GetParentElement();
        }
    }
}
