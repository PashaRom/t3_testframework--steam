using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Framework.Logging;
using App.Framework.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace App.Framework.WebDriver
{
    public class WebDriver {
        private IWebDriver webDriver;
        private string nameDriver;

        public WebDriver() {
            try {
                if (ConfigurationManager.ChromeOptions.IsActive && ConfigurationManager.FirefoxOptions.IsActive)
                    throw new Exception("Param \"isActive\" must be false one.");
                if (ConfigurationManager.ChromeOptions.IsActive && ConfigurationManager.FirefoxOptions.IsActive)
                    throw new Exception("Param \"isActive\" must be true one.");
                if (ConfigurationManager.ChromeOptions.IsActive) {
                    webDriver = CreatorWebDriver.CreateChromeDriver();
                    nameDriver = "ChromeDriver";
                }
                else if (ConfigurationManager.FirefoxOptions.IsActive) {
                    webDriver = CreatorWebDriver.CreateFirefoxDriver();
                    nameDriver = "FirefoxDriver";
                }
            }
            catch (Exception ex) {
                AppLog.Fatal(ex, "WebDriver has not been created.");
            }
        }

        public void GoToUrl(string url) {
            AppLog.Info($"Go to url {url}");
            webDriver.Url = url;
        }

        public IWebElement FindElement(By by) {
            AppLog.Info($"Find element {by.ToString()}");
            return webDriver.FindElement(by);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            IReadOnlyCollection<IWebElement> webElements = null;
            try {
                webElements = webDriver.FindElements(by);
                if (webElements.Count == 0) {
                    AppLog.Error($"The element {by.ToString()} has been not found.");

                    return webElements;
                }
                else
                    return webElements;
            }
            catch (Exception ex) {
                AppLog.Fatal(ex,"Error was recieved item menu element.");
                return webElements;
            }
        }

        public WebDriverWait ExplicitWait(TimeSpan timeSpan) {
            WebDriverWait webDriverWait = null;
            try {
                webDriverWait = new WebDriverWait(webDriver, timeSpan);
                return webDriverWait;
            }
            catch (Exception ex){
                AppLog.Fatal(ex, "ExplicitWait has not been created.");
            }
            return null;
        }

        public void MoveToElement(IWebElement webElement) {
            Actions act = new Actions(InstantWebDriver.WebDriver.webDriver);
            //IWebElement browser = topMenu.GetMenuItem(StaticData.BrowseMenuItem.Name);
            act.MoveToElement(webElement);
            act.Build().Perform();
        }

        public void ExecuteScript(string javaScript) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript(javaScript);
        }

        public IWebDriver GetWebDriver() {
            return webDriver;
        }

        public void Quit() {            
            webDriver.Quit();
            AppLog.Info($"{nameDriver} was quit.");
        }

        public void Close() {
            webDriver.Close();
            AppLog.Info($"{nameDriver} was closed.");
        }
        ~WebDriver() {
            Quit();
        }
    }
}
