using System;
using System.Collections.Generic;
using System.Text;
using App.ObjectPages.Forms;
using OpenQA.Selenium;

namespace App.ObjectPages
{
    public class GamePage
    {
        public GameAreaPurchase GetGameAreaPurchase(By locator) {
            return new GameAreaPurchase(locator);
        }
    }
}
