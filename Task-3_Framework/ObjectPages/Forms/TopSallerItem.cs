using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.Models;
using OpenQA.Selenium;

namespace App.ObjectPages.Forms
{
    class TopSallerItem : BaseElement
    {
        
        public TopSallerItem(By locator, BaseElement topSallersRows) : base(locator) {
            this.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
        }

        //public Price Price { 
        //    get
        //}
    }
}
