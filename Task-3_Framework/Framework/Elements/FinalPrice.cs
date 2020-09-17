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
         
        //public float Price {
        //    get
        //    {
        //        string strPrice = StringPrice;
        //        if (!String.IsNullOrEmpty(strPrice))
        //        {
        //            string remStrPrice = StringPrice.Remove(0);
        //            float price = float.Parse(remStrPrice);
        //            AppLog.Info($"The full price {strPrice} has converted into {price.ToString("f:2")}.");
        //            return price;
        //        }
        //        AppLog.Error($"The full price {strPrice} has not converted into float.");
        //        return 0;
        //    }
        //}
        
    }
}
