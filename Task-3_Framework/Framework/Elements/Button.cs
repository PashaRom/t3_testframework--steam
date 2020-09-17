using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Logging;
using OpenQA.Selenium;

namespace App.Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator) { }
        public string GetHref() {
            string href = null;
            href = webElement.GetAttribute("href");
            if (href == null)
                AppLog.Error($"WebElement {webElement.ToString()} do not have atribute \"href\"");
            return href;
        }
    }
}
