using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.Framework.Logging;
using App.TestData.Constants;
using OpenQA.Selenium;

namespace App.ObjectPages.Forms
{
    public class TabMenu {
        Tab tab;
        string locator;
        string tabItemName;
        public TabMenu(string name, string locator) {
            this.locator = locator;
            this.tabItemName = name;
            tab = new Tab(By.XPath(locator));
            tab.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if (tab.IsNull)
                AppLog.Error($"The tab locator \"{locator}\" has not found.");
            else
                AppLog.Info($"The tab locator \"{locator}\" has found.");
        }
        public void OpenTab() {
            tab.Click();
            AppLog.Info($"The tab item \"{tabItemName}\"has been clicked");
    }

        public bool TabIsOpened() {
            Tab openTab = new Tab(By.XPath(Locator.TabTopSellerContent));
            openTab.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if (openTab.IsVisible) {
                AppLog.Info($"The tab {tabItemName} has been opened.");
                return true;
            }
            else {
                AppLog.Error($"The tab {tabItemName} has not been opened.");
                return openTab.IsVisible;
            }
            
        }
    }
}
