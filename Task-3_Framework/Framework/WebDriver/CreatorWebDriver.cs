using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using App.Framework.Configuration;
using App.Framework.Logging;
using App.Utilits;

namespace App.Framework.WebDriver
{
    public static class CreatorWebDriver {
        public static IWebDriver CreateChromeDriver() {
            IWebDriver webDriver = null;
            try
            {
                AppLog.Info("Create CromeDriver.");                
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.LeaveBrowserRunning = ConfigurationManager.ChromeOptions.Options.LeaveBrowserRunning;
                chromeOptions.AddArgument(ConfigurationManager.ChromeOptions.Options.StartSizeWindow);
                chromeOptions.AddArgument(ConfigurationManager.ChromeOptions.Options.Mode);
                chromeOptions.AddArgument("--safebrowsing-disable-download-protection");
                chromeOptions.AddUserProfilePreference("safebrowsing", "enabled");
                chromeOptions.AddUserProfilePreference("download.default_directory",WorkWithFile.CheckDownloadDirectory(ConfigurationManager.PathDownload));
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                webDriver = new ChromeDriver(
                    ConfigurationManager.ChromeOptions.PathToDriver,
                    chromeOptions);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationManager.ChromeOptions.Options.ImplicitWait);
                AppLog.Info("ChromeDriver has been created.");
                return webDriver;
            }
            catch (Exception ex) {
                AppLog.Fatal(ex,"While creating chrome driver was error.");
            }
            return webDriver;
        }

        public static IWebDriver CreateFirefoxDriver() {
            IWebDriver webDriver = null;
            try {
                AppLog.Info("Create FirefoxDriver.");
                FirefoxOptions firefoxOptions = new FirefoxOptions();                
                firefoxOptions.AddArgument(ConfigurationManager.FirefoxOptions.Options.StartSizeWindow);
                firefoxOptions.SetPreference("browser.download.folderList", 2);
                firefoxOptions.SetPreference("browser.download.manager.showWhenStarting", false);
                firefoxOptions.SetPreference("browser.download.dir", WorkWithFile.CheckDownloadDirectory(ConfigurationManager.PathDownload));
                firefoxOptions.SetPreference("browser.download.downloadDir", WorkWithFile.CheckDownloadDirectory(ConfigurationManager.PathDownload));
                firefoxOptions.SetPreference("browser.download.defaultFolder", WorkWithFile.CheckDownloadDirectory(ConfigurationManager.PathDownload));
                firefoxOptions.SetPreference("browser.download.useDownloadDir", true);
                firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");                                                                                         
                webDriver = new FirefoxDriver(
                    ConfigurationManager.FirefoxOptions.PathToDriver,
                    firefoxOptions);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationManager.FirefoxOptions.Options.ImplicitWait);
                AppLog.Info("FirefoxDriver has been created.");
                return webDriver;
            }
            catch (Exception ex)
            {
                AppLog.Fatal(ex, "While creating firefox driver was error.");
            }
            return webDriver;
        }
    }
}
