using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using App.Framework.Configuration.Models;
using App.Framework.Logging;
using System.Collections.Generic;



namespace App.Framework.Configuration
{
    public static class ConfigurationManager
    {
        public const string SettingFile = "testconfig.json";
        public readonly static BrowserOptions ChromeOptions;
        public readonly static BrowserOptions FirefoxOptions;
        static ConfigurationManager() {
            var builder = new ConfigurationBuilder().AddJsonFile("testconfig.json");
            GetConfiguration = builder.Build();
            ChromeOptions = GetChromeOptions();
            FirefoxOptions = GetFirefoxOptions();
        }
        private static IConfiguration GetConfiguration { get; }

        private static BrowserOptions GetChromeOptions() {
            BrowserOptions chrome = new BrowserOptions();
            chrome.Options = new Options();
            try {
                AppLog.Info("Recieving settings for chrome driver");
                chrome.PathToDriver = CheckIsNullValue(nameof(chrome.PathToDriver), GetConfiguration["browsers:chrome:pathToDriver"]);
                if (String.IsNullOrEmpty(chrome.PathToDriver))
                    throw new Exception("Peram \"pathToDriver\" must write.");
                string isActive = CheckIsNullValue(nameof(chrome.IsActive), GetConfiguration["browsers:chrome:isActive"]);
                if(String.IsNullOrEmpty(isActive))
                    AppLog.Warn("Param isActive must be \"true\" or \"false\"");
                chrome.IsActive = ConvertStringToBool(isActive);
                string implicitWait = CheckIsNullValue(nameof(chrome.Options.ImplicitWait), GetConfiguration["browsers:chrome:options:implicitWait"]);
                chrome.Options.ImplicitWait = implicitWait == null? 0 : Convert.ToInt32(implicitWait);
                string leaveBrowserRunning = CheckIsNullValue(nameof(leaveBrowserRunning), GetConfiguration["browsers:chrome:options:leaveBrowserRunning"]);
                if (!String.IsNullOrEmpty(leaveBrowserRunning))
                    chrome.Options.LeaveBrowserRunning = leaveBrowserRunning.Equals("true") ? true : false;
                chrome.Options.Mode = CheckIsNullValue(nameof(chrome.Options.Mode),GetConfiguration["browsers:chrome:options:mode"]);
                chrome.Options.StartSizeWindow = CheckIsNullValue(nameof(chrome.Options.StartSizeWindow),GetConfiguration["browsers:chrome:options:startSizeWindow"]);
                AppLog.Info("Chrome driver options have been recieved");
                return chrome;
            }
            catch(Exception ex) {
                AppLog.Fatal(ex,"Has got troubles with receive optionf for CromeWebDriver");
            }
            return chrome;
        }

        private static BrowserOptions GetFirefoxOptions() {
            BrowserOptions firefox = new BrowserOptions();
            firefox.Options = new Options();
            try {
                AppLog.Info("Recieving settings for firefox driver");
                firefox.PathToDriver = CheckIsNullValue(nameof(firefox.PathToDriver), GetConfiguration["browsers:firefox:pathToDriver"]);
                if (String.IsNullOrEmpty(firefox.PathToDriver))
                    throw new Exception("Peram \"pathToDriver\" must write.");
                string isActive = CheckIsNullValue(nameof(firefox.IsActive), GetConfiguration["browsers:firefox:isActive"]);
                if (String.IsNullOrEmpty(isActive))
                    AppLog.Warn("Param isActive must be \"true\" or \"false\"");
                firefox.IsActive = ConvertStringToBool(isActive);
                string implicitWait = CheckIsNullValue(nameof(firefox.Options.ImplicitWait), GetConfiguration["browsers:firefox:options:implicitWait"]);
                firefox.Options.ImplicitWait = implicitWait == null ? 0 : Convert.ToInt32(implicitWait);
                string leaveBrowserRunning = CheckIsNullValue(nameof(leaveBrowserRunning), GetConfiguration["browsers:chrome:options:leaveBrowserRunning"]);
                if (!String.IsNullOrEmpty(leaveBrowserRunning))
                    firefox.Options.LeaveBrowserRunning = leaveBrowserRunning.Equals("true") ? true : false;
                firefox.Options.Mode = CheckIsNullValue(nameof(firefox.Options.Mode), GetConfiguration["browsers:firefox:options:mode"]);
                firefox.Options.StartSizeWindow = CheckIsNullValue(nameof(firefox.Options.StartSizeWindow), GetConfiguration["browsers:firefox:options:startSizeWindow"]);
                AppLog.Info("Firefox driver options have been recieved");
                return firefox;
            }
            catch (Exception ex) {
                AppLog.Fatal(ex, "Has got troubles with receive options for FirefoxDriver");
            }
            return firefox;
        }

        public static string TestingUrl {
            get { 
                string fulltestingUrl = null;
                try {
                    string testingUrl = CheckIsNullValue(nameof(testingUrl),GetConfiguration["testingUrl"]);
                    if (String.IsNullOrEmpty(testingUrl))
                        throw new Exception("Param \"testingUrl\" must write.");
                    //string localozation = ConfigurationManager.Localization;
                    fulltestingUrl = $"{testingUrl}/?l={ConfigurationManager.Localization}";
                    return fulltestingUrl;
                }
                catch (Exception ex) {
                    AppLog.Fatal(ex, "Has got troubles with receive url.");
                }
                return fulltestingUrl;
            }
        }

        public static string Localization {            
            get {
                try { 
                    List<Language> languages = new List<Language>();
                    var valuesSection = GetConfiguration.GetSection("localization");
                    foreach (IConfigurationSection section in valuesSection.GetChildren()) {
                        Language language = section.Get<Language>();
                        language.Name = CheckIsNullValue(nameof(language.Name), language.Name);
                        //string isActive = null;
                        //language.isActive;// = CheckIsNullValue(nameof(language.isActive), language.isActive);
                        if (String.IsNullOrEmpty(language.Name)) {
                            AppLog.Error($"The param \"localization:name\" has value null or empty.");
                            continue;                            
                        }
                        languages.Add(language);    
                    }
                    int countTrue = 0, countFalse = 0;
                    foreach (Language lang in languages) {
                        if (lang.isActive)
                            countTrue++;
                        if(!lang.isActive)
                            countFalse++;
                    }
                    if (countTrue > 1)
                        throw new Exception("Param \"isActiv\" must be \"true\" only one in param \"localization\"");
                    if (languages.Count == countFalse)
                        throw new Exception("Param \"isActiv\" must not be \"false\"  in param \"localization\" everywhere.");
                    foreach (Language lang in languages) {
                        if (lang.isActive)
                            return lang.Name;
                    }
                }
                catch(Exception ex) {
                    AppLog.Fatal(ex, "The error was appeared during to read language param from testconfig file.");
                    return null;
                }               
                return null;
                }
                    
            }
        public static int LoopChekingFile {
            get {
                string loopChekingFile = CheckIsNullValue(nameof(loopChekingFile), GetConfiguration["checkingDownloadFile:loopCheking"]);
                if (loopChekingFile != null) {
                    AppLog.Info($"The param checkingDownloadFile:loopCheking has been read.");
                    return Convert.ToInt32(loopChekingFile);
                }
                else
                    AppLog.Error($"The param checkingDownloadFile:loopCheking has not been read.");
                return 0;
            }
        }

        public static int IntervalChekingFile {
            get { 
                string intervalChekingFile = CheckIsNullValue(nameof(intervalChekingFile), GetConfiguration["checkingDownloadFile:interval"]);
                if (intervalChekingFile != null)
                {
                    AppLog.Info($"Param checkingDownloadFile:interval has been read.");
                    return Convert.ToInt32(intervalChekingFile);
                }
                else
                    AppLog.Error($"Param checkingDownloadFile:interval has not been read.");
                return 0;
            }
        }

        public static int SizeFile
        {
            get
            {
                string sizeFile = CheckIsNullValue(nameof(sizeFile), GetConfiguration["checkingDownloadFile:size"]);
                if (sizeFile != null)
                {
                    AppLog.Info($"Param checkingDownloadFile:size has been read.");
                    return Convert.ToInt32(sizeFile);
                }
                else
                    AppLog.Error($"Param checkingDownloadFile:size has not been read.");
                return 0;
            }
        }
        public static string PathDownload {
            get {
                string pathDownload = null;
                try {
                    pathDownload = CheckIsNullValue(nameof(pathDownload),GetConfiguration["pathDownload"]);
                    return pathDownload;
                }
                catch(Exception ex) {
                    AppLog.Fatal(ex, "Error was read \"pathDownload\" from testconfig file.");
                    return pathDownload;
                }
            }
        }

        private static string CheckIsNullValue(string param,string value) { 
            if(String.IsNullOrEmpty(value)) {
                AppLog.Trace($"Param ${param} has got value null");
                return null;
            }
            return value;
        }

        private static bool ConvertStringToBool(string booleanString) {
            try {
                if (!String.IsNullOrEmpty(booleanString))
                    return Convert.ToBoolean(booleanString);               
            }
            catch(Exception ex) {
                AppLog.Fatal(ex, "Error converted string to boolean.");
            }
            return false;
        }

        
              
    }
}
