using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using OpenQA.Selenium;

namespace App.Framework.Elements
{
    public class Div : BaseElement
    {
        public Div() { }
        public Div(By locator) : base(locator) { }
    }
}
