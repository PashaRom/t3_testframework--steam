using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using App.Framework.WebDriver;
using App.Framework.Logging;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace App.Framework.Elements
{
    public abstract class BaseElement : IWebElement
    {
        protected IWebElement webElement = null;
        
        protected By Locator;
        public BaseElement() { }
        public BaseElement(By locator) {
            this.Locator = locator;
        }
        public bool IsNull {
            get {
                return webElement == null ? true : false;
            }
        }
        public IWebElement Element {
            get {
                return webElement;
            }
            set
            {
                webElement = value; 
            }
        }

        public string GetAtribut(string atribute) {
            string value = null;
            try {
                value = webElement.GetAttribute(atribute);
                return value;
            }
            catch (Exception ex) {
                AppLog.Fatal(ex,$"While atribute {atribute} was recieving to throw the error.");
                return value;
            }
        }
        public void ImplicitWaitFindElement() {            
            try {
                AppLog.Info($"Searching element {Locator.ToString()}");
                webElement = InstantWebDriver.WebDriver.FindElement(Locator);
                AppLog.Info($"Web element { Locator.ToString()} has been found.");
            }
            catch(Exception ex) {
                AppLog.Error(ex,$"Web element {Locator.ToString()} has not been found.");
                //webElement = null;
            }
        }

        public IWebElement ImplicitWaitFindChaildElement(By chaildLocator)
        {
            IWebElement chaildWebElement = null;
            try
            {
                AppLog.Info($"Searching the child element {chaildLocator.ToString()} in the parent element {Locator.ToString()}");
                chaildWebElement = webElement.FindElement(chaildLocator);
                AppLog.Info($"The child element {chaildLocator.ToString()} in the parent element {Locator.ToString()} has been found.");
                return chaildWebElement;
            }
            catch (Exception ex)
            {
                AppLog.Error(ex, $"The child element {chaildLocator.ToString()} in the parent element {Locator.ToString()} has not been found.");
                //webElement = null;
                return chaildWebElement;
            }

        }

        public IReadOnlyCollection<IWebElement> ImplicitWaitFindElements(By by)
        {
            IReadOnlyCollection<IWebElement> childWebElements = null;
            try
            {
                AppLog.Info($"Searching element {by.ToString()}");
                string sd = webElement.GetAttribute("id");
                string sdf = webElement.GetAttribute("class");
                childWebElements = webElement.FindElements(by);
                
                if(childWebElements.Count == 0)
                    AppLog.Error($"The web elements { by.ToString()} has not been found.");
                else
                    AppLog.Info($"Web elements { by.ToString()} has been found.");
                return childWebElements;
            }
            catch (Exception ex)
            {
                AppLog.Error(ex, $"Web elements {by.ToString()} has not been found.");
                //webElement = null;
                return childWebElements;
            }

        }

        //public void ImplicitWaitFindElements(By by) {
        //AppLog.Info($"Searching element {by.ToString()}");
        //}

        public void ExplicitWaitExistFindElement(TimeSpan timeSpan) {           
            try {
                WebDriverWait webDriverWait = InstantWebDriver.WebDriver.ExplicitWait(timeSpan);
                webElement = webDriverWait.Until(ExpectedConditions.ElementExists(Locator));
                AppLog.Info($"Web element { Locator.ToString()} has been found.");
            }
            catch(Exception ex) {
                AppLog.Error(ex, $"Web element {Locator.ToString()} has not been existed.");
                //webElement = null;
            }
        }
        public void ExplicitWaitToBeClickableFindElement(By by, TimeSpan timeSpan)
        {
            try
            {
                WebDriverWait webDriverWait = InstantWebDriver.WebDriver.ExplicitWait(timeSpan);
                webElement = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
                AppLog.Info($"Web element { by.ToString()} has been found.");
            }
            catch (Exception ex)
            {
                AppLog.Error(ex, $"Web element {by.ToString()} has not been existed.");
                //webElement = null;
            }
        }

        public bool MoveTo(IWebElement menuItem)
        {
            InstantWebDriver.WebDriver.MoveToElement(menuItem);
            return true;
        }

        public bool IsVisible {
            get {
                return webElement.Displayed;
            }
        }

        public void Click() {
            try {
                if (!this.IsNull) {
                    Actions action = new Actions(InstantWebDriver.WebDriver.GetWebDriver());
                    action.MoveToElement(webElement);
                    action.Perform();
                    webElement.Click();
                    //webElement.Click();

                }
                else
                    throw new Exception("Web element do not click because it has value null.");
            }
            
            catch(Exception ex) {
                AppLog.Error(ex, $"Error was to click");
            }
        }

        public void Clear() {
            webElement.Clear();
        }
        public void SendKeys(string text)
        {
            webElement.SendKeys(text);
        }
        public void Submit() {
            webElement.Submit();
        }

        public string GetAttribute(string attributeName) {
            return webElement.GetAttribute(attributeName);
        }
        public string GetProperty(string propertyName) {
            return webElement.GetProperty(propertyName);
        }
        public string GetCssValue(string propertyName) {
            return webElement.GetCssValue(propertyName);
        }
        public string TagName {
            get {
                return webElement.TagName;
            }
        }
        public string Text { 
            get {
                return webElement.Text;
            } 
        }

        public bool Enabled { 
            get {
                return webElement.Enabled;
            } 
        }
        public bool Selected { 
            get {
                return webElement.Selected;
            } 
        }
        public Point Location {
            get {
                return webElement.Location;
            } 
        }

        public Size Size {
            get {
                return webElement.Size;
            } 
        }
        public bool Displayed {
            get {
                return webElement.Displayed;
            } 
        }
        public IWebElement FindElement(By by) {
            return webElement.FindElement(by);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By by) {
            return webElement.FindElements(by);
        }
    }
}
