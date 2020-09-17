using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace App.Framework.Elements
{
    class H2 : BaseElement {
        
        public H2(By locator):base(locator) { }
        public string GetText {
            get { 
                return webElement.Text;
            }
        }
    }
}
