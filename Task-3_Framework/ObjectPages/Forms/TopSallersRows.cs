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
            //string parent = parentWebElement.GetAttribute("id");
        }

        public Price GetTopPrice(By locatorOriginalPrice, By locatorFinalPrice, By locatorDiscount) { 
            //TopSallerItem topSallerItem = new TopSallerItem(locator,)
            //List<Price> prices = new List<Price>();
            
            Price price = new Price();
            int i = 0;
            foreach (IWebElement we in webElements) {
                Price tempPrice = new Price();
                FinalPrice finalPrice = new FinalPrice();
                OriginalPrice originalPrice = new OriginalPrice();
                Discount discount = new Discount();
                //string str = we.TagName;
                //string cl = we.GetAttribute("class");
                //string hr = we.GetAttribute("href");
                //try
                //{
                //    IWebElement web = we.FindElement(By.XPath("./div[contains(@class,'discount_block')]/div[@class='discount_prices']/div[@class='discount_original_price']"));
                //    string tag = web.TagName;
                //    string clas = web.GetAttribute("class");
                //}
                //catch (Exception ex) { }
                try {
                    originalPrice.Element = we.FindElement(locatorOriginalPrice);
                 }
                catch(NoSuchElementException ex) {
                    originalPrice.Element = null;
                }
                try { 
                //IWebElement oP = we.FindElement(locatorOriginalPrice);
                finalPrice.Element = we.FindElement(locatorFinalPrice);
                //IWebElement fP = we.FindElement(locatorFinalPrice);
                }
                catch(NoSuchElementException ex) {
                    finalPrice.Element = null;
                }
                try
                {
                    discount.Element = we.FindElement(locatorDiscount);
                }
                catch (NoSuchElementException ex) {
                    discount.Element = null;
                }
                
                //IWebElement d = we.FindElement(locatorDiscount);
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
