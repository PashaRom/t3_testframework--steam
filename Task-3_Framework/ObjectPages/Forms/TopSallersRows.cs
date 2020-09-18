using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.Models;
using OpenQA.Selenium;
using App.ObjectPages.Forms;
using App.Framework.Logging;


namespace App.ObjectPages.Forms
{
    public class TopSallersRows : BaseElement
    {
        private IReadOnlyCollection<IWebElement> webElements = null;
        public TopSallersRows(By locator, BaseElement parentWebElement) : base(locator) {
            webElements = parentWebElement.ImplicitWaitFindElements(this.Locator);
        }

        public Price GetTopPrice(By locatorOriginalPrice, By locatorFinalPrice, By locatorDiscount) { 
            Price price = new Price();
            int i = 0;
            foreach (IWebElement we in webElements) {
                Price tempPrice = new Price();
                FinalPrice finalPrice = new FinalPrice();
                OriginalPrice originalPrice = new OriginalPrice();
                Discount discount = new Discount();                
                try {
                    originalPrice.Element = we.FindElement(locatorOriginalPrice);
                 }
                catch(NoSuchElementException ex) {
                    originalPrice.Element = null;
                }
                try { 
                finalPrice.Element = we.FindElement(locatorFinalPrice);
                }
                catch(NoSuchElementException ex) {
                    finalPrice.Element = null;
                }
                try {
                    discount.Element = we.FindElement(locatorDiscount);
                }
                catch (NoSuchElementException ex) {
                    discount.Element = null;
                }
                if (discount.IsNull && originalPrice.IsNull && finalPrice.IsNull)
                    continue;
                if (discount.IsNull)
                    tempPrice.Discount = 0;
                else                    
                    tempPrice.Discount = Convert.ToInt32(discount.Price());
                if (originalPrice.IsNull)
                    tempPrice.OriginalPrice = 0;
                else
                    tempPrice.OriginalPrice = originalPrice.Price();
                if (finalPrice.IsNull)
                    tempPrice.FinalPrice = 0;
                else
                    tempPrice.FinalPrice = finalPrice.Price();

                tempPrice.WebElement = we;                
                if (i == 0) {                    
                    price = tempPrice;
                    i++;
                    continue;
                }
                if (price > tempPrice)
                    price = tempPrice;
            }
            return price;
        }

    }
}
