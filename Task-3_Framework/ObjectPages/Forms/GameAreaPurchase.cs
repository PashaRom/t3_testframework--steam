using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using OpenQA.Selenium;

namespace App.ObjectPages.Forms
{
    public class GameAreaPurchase :BaseElement
    {
        public GameAreaPurchase(By locator) : base(locator) {
            base.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
        }

        public PurchasesGame GetPurchasesGame(By locator) {
            return new PurchasesGame(locator, this);
        }
    }
}
