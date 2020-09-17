using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Framework.Logging;

namespace App.Framework.Elements
{
    class Discount : BasePrice
    {
        public Discount() { }
        public Discount(By locator, BaseElement parentElement) : base(locator)
        {
            webElement = parentElement.ImplicitWaitFindChaildElement(locator);
        }

        public override float Price()
        {
            string strPrice = StringPrice;
            if (!String.IsNullOrEmpty(strPrice))
            {
                string remStrPrice = StringPrice.Remove(strPrice.Length - 1);
                int price = Convert.ToInt32(remStrPrice);
                AppLog.Info($"The dicount {strPrice} has converted into {price.ToString("f:2")}.");
                return price;
            }
            AppLog.Error($"The discount {strPrice} has not converted into float.");
            return 0;
        }
    }
}
