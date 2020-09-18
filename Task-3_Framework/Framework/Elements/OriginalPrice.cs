using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Framework.Logging;

namespace App.Framework.Elements
{
    class OriginalPrice : BasePrice
    {
        public OriginalPrice() { }
        public OriginalPrice(By locator, BaseElement parentElement) : base(locator) {
            webElement = parentElement.ImplicitWaitFindChaildElement(locator);
        }        
    }
}
