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

        public bool IsOpen()
        {
            try
            {                
                InstantWebDriver.WebDriver.GoToUrl(ConfigurationManager.TestingUrl);
                //WebDriverWait webDriverWait = InstantWebDriver.WebDriver.ExplicitWait(TimeSpan.FromSeconds(5));
                Span spanLogoHolder = new Span(By.XPath(Locator.SpanLogoHolder));
                spanLogoHolder.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));//webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(Locator.CheckLoadHomePage)));                
                if (spanLogoHolder.IsNull) {
                    AppLog.Error("Home page has not opened.");
                    return false;
                }                
                AppLog.Info("Home page has opened.");
                //SwitchLanguage();                
                return true;
            }            
            catch (Exception ex)
            {
                AppLog.Fatal(ex, "Error was thrown while HomePage was opening.");
                return false;
            }
        }

        public void SwitchLanguage() {
            try { 
                string language = ConfigurationManager.Localization;
                if (String.IsNullOrEmpty(language))
                {
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
                //IJavaScriptExecutor js = (IJavaScriptExecutor)InstantWebDriver.WebDriver.GetWebDriver();
                //string pd = (String)js.ExecuteScript("return document.readyState");
                //js.ExecuteScript(javaScript);
                
                Button installSteamButton = new Button(By.XPath(Locator.ButtonInstallSteamHomePage));
                //installSteamButton.ExplicitWaitToBeClickableFindElement(By.XPath(Locator.ButtonInstallSteamHomePage), TimeSpan.FromSeconds(15));
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
            //topMenu.SelectMenuItems(StaticData.BrowseMenuItem.Locator);
            topMenu.SelectMenuItems(StaticData.BrowseMenuItem.Locator);
            IWebElement browser = topMenu.GetMenuItem(StaticData.BrowseMenuItem.Name);
            topMenu.MoveTo(browser);
            //Actions act = new Actions(InstantWebDriver.WebDriver.GetWebDriver());            
            //act.MoveToElement(browser);
            //act.Build().Perform();
            topMenu.SelectSubMenuItoms(StaticData.ActionSubMenuItem.Locator);
            IWebElement action = topMenu.GetSubMenuItem(StaticData.ActionSubMenuItem.Name);            
            topMenu.Click(browser, action);
        }        
    }
}
        
    

