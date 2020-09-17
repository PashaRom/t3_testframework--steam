using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.Models;
using OpenQA.Selenium;
using App.Framework.Logging;

namespace App.ObjectPages.Forms
{
    public class PurchasesGame : BaseElement {
        IReadOnlyCollection<IWebElement> Purchases;
        public PurchasesGame(By locator, BaseElement parentElement) : base(locator) {
            Purchases = parentElement.ImplicitWaitFindElements(base.Locator);
        }

        public List<Price> GetPrice(By locatorOriginalPrice, By locatorFinalPrice, By locatorDiscoun) {
            AppLog.Info("Start looking up discount prices");
            List<Price> prices = new List<Price>();
            foreach(IWebElement curWebElement in Purchases) {
                OriginalPrice originalPrice = new OriginalPrice();
                FinalPrice finalPrice = new FinalPrice();
                Discount discount = new Discount();
                Price price = new Price();
                originalPrice.Element = curWebElement.FindElement(locatorOriginalPrice);
                finalPrice.Element = curWebElement.FindElement(locatorFinalPrice);
                discount.Element = curWebElement.FindElement(locatorDiscoun);
                price.OriginalPrice = originalPrice.Price();
                price.FinalPrice = finalPrice.Price();
                price.Discount = Convert.ToInt32(discount.Price());
                prices.Add(price);
            }
            return prices;
        }


    }
}
