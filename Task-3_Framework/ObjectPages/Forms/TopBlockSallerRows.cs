using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using OpenQA.Selenium;

namespace App.ObjectPages.Forms
{
    public class TopBlockSallerRows : BaseElement
    {
        public TopBlockSallerRows(By locator) : base (locator) {
            base.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
        }

        public TopSallersRows GetTopSallerRows(By locator) {
           TopSallersRows topSallersRows = new TopSallersRows(locator, this);
           return topSallersRows;
            
        }
    }
}
