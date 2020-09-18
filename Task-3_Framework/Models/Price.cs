using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace App.Models
{
    public class Price
    {
        public float OriginalPrice { get; set; }
        public float FinalPrice { get; set; }
        public int Discount { get; set; }
        public IWebElement WebElement { get; set; }

        public bool IsNull {
            get {
                if (OriginalPrice == 0 && FinalPrice == 0 && Discount == 0 && WebElement == null)
                    return true;
                else
                    return false;
            }
        }

        public override bool Equals(object obj) {
            if (obj.GetType() != this.GetType())
                return false;
            Price price = obj as Price;
            if (this.OriginalPrice == price.OriginalPrice && this.FinalPrice == price.FinalPrice && this.Discount == price.Discount)
                return true;
            else
                return false;
        }

        public static bool operator >(Price price1 , Price price2) {
            return price1.Discount > price2.Discount;
        }
        public static bool operator <(Price price1, Price price2) {
            return price1.Discount < price2.Discount;
        }
    }
}
