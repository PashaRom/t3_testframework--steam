using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Framework.Logging;

namespace App.Framework.Elements
{
    class FinalPrice : BasePrice
    {
        public FinalPrice() { } 
        public FinalPrice(By locator, BaseElement parentElement) : base(locator) {
            webElement = parentElement.ImplicitWaitFindChaildElement(locator);
        }
        
    }
}
