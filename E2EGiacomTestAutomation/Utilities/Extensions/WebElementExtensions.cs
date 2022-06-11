namespace E2EGiacomTestAutomation.Utilities.Extensions
{
    using Helpers;
    using OpenQA.Selenium;

    public static class WebElementExtensions
    {
        public static void JsClick(this IWebElement element)
        {
            SeleniumExecutor.JavaScriptExecutor.ExecuteScript("var el=arguments[0]; setTimeout(function() { el.click(); }, 200);", element);
        }

        public static void SendKeysWithWait(this IWebElement element, string text)
        {
            Wait.UntilElementIsDisplayed(element);
            element.SendKeys(text);
        }

        public static void SendKeysWithClear(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static IWebElement GetParentElement(this IWebElement element)
        {
            return element.FindElement(By.XPath("./.."));
        }

        public static void HoverOverElement(this IWebElement element)
        {
            var action = SeleniumExecutor.Actions;
            action.MoveToElement(element).Perform();
        }

        public static void DragAndDrop(IWebElement source, IWebElement target)
        {
            var action = SeleniumExecutor.Actions;
            action.DragAndDrop(source, target).Perform();
        }

        public static void ClickAndHold(this IWebElement source)
        {
            var action = SeleniumExecutor.Actions;
            action.ClickAndHold(source).Perform();
        }
    }
}
