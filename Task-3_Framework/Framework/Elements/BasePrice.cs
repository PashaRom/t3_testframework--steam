using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Framework.Logging;
using System.Text.RegularExpressions;

namespace App.Framework.Elements
{
    public abstract class BasePrice : BaseElement
    {
        public BasePrice() { }

        public BasePrice(By locator) : base(locator) { }

        public string StringPrice
        {
            get
            {
                string strPrice = "0";
                try {
                    strPrice = webElement.Text;
                    if (String.IsNullOrEmpty(strPrice))
                        AppLog.Error($"The element \"{this.Locator}\" do not have a value.");
                    else {
                        AppLog.Error($"The element \"{this.Locator}\" have got price {strPrice}.");
                    }
                    return strPrice;
                }
                catch(Exception ex){
                    AppLog.Error(ex,$"The element \"{this.Locator}\" do not have a value.");
                    return strPrice;
                }
                
            }
        }
        public virtual float Price()
        {
            string strPrice = StringPrice;
            if (!Regex.IsMatch(strPrice, @"\d+")) {
                AppLog.Info($"The price \"{Locator}\" has value {strPrice}.");
                return 0;                
            }
            if (!String.IsNullOrEmpty(strPrice))
            {
                string remStrPrice = null;
                if (Regex.IsMatch(strPrice, @"USD$")) {
                    strPrice = strPrice.Remove(strPrice.Length-4, 3).Replace('.', ',');                    
                }
                remStrPrice = strPrice.Remove(0,1).Replace('.',',');
                
                float price = float.Parse(remStrPrice);
                AppLog.Info($"The price \"{Locator}\" {strPrice} has converted into {price.ToString("f:2")}.");
                return price;
            }
            AppLog.Error($"The full price \"{Locator}\" {strPrice} has not converted into float.");
            return 0;
           
        }

        private float StringToFloat(string input) {
            string[] numbers = Regex.Split(input, @"\D+");
            float number = 0;
            try { 
                foreach (string value in numbers) {
                    if (!string.IsNullOrEmpty(value)) { 
                        number = int.Parse(value);
                    }
                }
                return number;
            }
            catch(Exception ex) {
                AppLog.Fatal(ex,"The error was appeared during convert string to float.");
                return number;
            }
        }

       
    }
}
