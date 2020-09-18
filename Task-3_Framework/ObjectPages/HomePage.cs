using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Drawing;
using App.Framework.Logging;
using App.Framework.WebDriver;
using App.Framework.Configuration;
using App.TestData.Constants;
using App.Framework.Elements;
using App.TestData;
using App.ObjectPages.Forms;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace App.ObjectPages
{
    public class HomePage
    {
        public bool IsOpen() {
            try {                
                InstantWebDriver.WebDriver.GoToUrl(ConfigurationManager.TestingUrl);                
                Span spanLogoHolder = new Span(By.XPath(Locator.SpanLogoHolder));
                spanLogoHolder.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));              
                if (spanLogoHolder.IsNull) {
                    AppLog.Error("Home page has not opened.");
                    return false;
                }                
                AppLog.Info("Home page has opened.");                                
                return true;
            }            
            catch (Exception ex) {
                AppLog.Fatal(ex, "Error was thrown while HomePage was opening.");
                return false;
            }
        }

        public void SwitchLanguage() {
            try { 
                string language = ConfigurationManager.Localization;
                if (String.IsNullOrEmpty(language)) {
                    throw new Exception("Language must be to have value.");
                }
                InstantWebDriver.WebDriver.ExecuteScript($"ChangeLanguage('{language}'); return false;");
                AppLog.Info($"Language on page has been changed. Current value is {language}.");
            }
            catch(Exception ex) {
                AppLog.Error(ex,"Languadge has not been swithed.");
            }
        }

        public void ClickButtonInstallSteam() {
            try {                
                Button installSteamButton = new Button(By.XPath(Locator.ButtonInstallSteamHomePage));                
                installSteamButton.ImplicitWaitFindElement();
                if (installSteamButton.IsNull)
                    AppLog.Error("Button \"Instal Steam\" has got value null.");
                installSteamButton.Click();
                AppLog.Info("Button \"Instal Steam\" has been clicked.");
            }
            catch(Exception ex) {
                AppLog.Error(ex, "Button \"Instal Stream\" has not been clicked.");
            }
        }

        public void SelectGamesTopMenu() {
            Menu topMenu = new Menu(By.XPath(Locator.TopMenu));            
            topMenu.SelectMenuItems(StaticData.BrowseMenuItem.Locator);
            IWebElement browser = topMenu.GetMenuItem(StaticData.BrowseMenuItem.Name);
            topMenu.MoveTo(browser);            
            topMenu.SelectSubMenuItoms(StaticData.ActionSubMenuItem.Locator);
            IWebElement action = topMenu.GetSubMenuItem(StaticData.ActionSubMenuItem.Name);            
            topMenu.Click(browser, action);
        }        
    }
}
        
    

