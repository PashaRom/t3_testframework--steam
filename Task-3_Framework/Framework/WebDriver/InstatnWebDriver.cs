using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace App.Framework.WebDriver
{
    public static class InstantWebDriver {

        private static WebDriver webDriver = null;

        public static WebDriver WebDriver
        {
            get {
                if (webDriver == null)
                {
                    webDriver = new WebDriver(); ;
                }
                return webDriver;
            }
        }
    }
}
