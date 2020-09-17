using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Logging;
using OpenQA.Selenium;
using App.Framework.WebDriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace App.Framework.Elements
{
    public class Menu : BaseElement
    {
        IWebElement menuItem;
        IWebElement subMenuItem;
        IReadOnlyCollection<IWebElement> menuItems;
        IReadOnlyCollection<IWebElement> subMenuItems;
        public Menu(By locator):base (locator){
            ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));

        }
        
        public IReadOnlyCollection<IWebElement> SelectMenuItems(string locator) {
            menuItems = webElement.FindElements(By.XPath(locator));
            //foreach (IWebElement se in webElements) {
            //    string f = se.GetAttribute("class");
            //    string s = se.Text;
            //}
            return menuItems;
        }
        public void SelectSubMenuItoms(string locator) {
            subMenuItems = webElement.FindElements(By.XPath(locator));
        }        

        public IWebElement GetMenuItem(string name) {
            
           foreach(IWebElement item in menuItems) {
                if (item.Text.Equals(name))
                    menuItem = item;
            }
            return menuItem;
        }
        public IWebElement GetMenuItem(IReadOnlyCollection<IWebElement> menuItems, string name)
        {

            foreach (IWebElement item in menuItems)
            {
                if (item.Text.Equals(name))
                    menuItem = item;
            }
            return menuItem;
        }

        public IWebElement GetSubMenuItem(string name) {
            foreach (IWebElement item in subMenuItems)
            {
                if (item.Text.Equals(name))
                    subMenuItem = item;
            }
            return subMenuItem;
        }        

        public void Click(IWebElement item1, IWebElement subItem1) {
            try {
                if (!this.IsNull) {
                    //Actions action = new Actions(InstantWebDriver.WebDriver.GetWebDriver());
                    //action.MoveToElement(menuItem);
                    //action.Perform();
                    //menuItem.Click();

                    Actions actionBuilder = new Actions(InstantWebDriver.WebDriver.GetWebDriver());
                    actionBuilder.MoveToElement(item1).Perform();
                    //By locator = By.id("clickElementID");
                    subItem1.Click();

                }
                else
                    throw new Exception("Web element do not click because it has value null.");
            }
            catch (Exception ex){
                AppLog.Error(ex, $"Error was to click");
            }
        }



        public void SelectItemClick(IWebElement element) {
            try {
                if (!this.IsNull) {
                    Actions action = new Actions(InstantWebDriver.WebDriver.GetWebDriver());
                    action.MoveToElement(element);
                    action.Perform();
                    element.Click();
                }
                else
                    throw new Exception("Web element do not click because it has value null.");
            }
            catch (Exception ex) {
                AppLog.Error(ex, $"Error was to click");
            }
        }
    }
}
