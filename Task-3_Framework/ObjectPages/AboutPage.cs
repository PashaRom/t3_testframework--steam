using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.TestData.Constants;
using OpenQA.Selenium;
using App.Framework.Logging;
using App.Utilits;
using App.Framework.Configuration;

namespace App.ObjectPages
{
    public class AboutPage {

        public bool IsOpen () {
            Button buttonInstallTeam = GetButtonInstallTeam();
            if (buttonInstallTeam.IsNull)
                return false;
            else {
                AppLog.Info("Button \"Install Team\" on \"About\" page has been found.");
                AppLog.Info("Page \"About\" has been opened.");
                return true;
            }
        }
        public Button GetButtonInstallTeam() {
            Button buttonInstallTeam = new Button(By.XPath(Locator.ButtonInstalLSteamAboutPage));
            try {                
                buttonInstallTeam.ImplicitWaitFindElement();
                if (buttonInstallTeam.IsNull)
                    throw new Exception("Button \"Install Team\" on \"About\" page has got value \"null\".");
               return buttonInstallTeam;
            }
            catch (Exception ex)
            {
                AppLog.Error(ex, "Error has got value \"InstallTeam\" button");
                return buttonInstallTeam;
            }
        }

        public void ClickButtonInstallTeam() {
            Button buttonInstallTeam = GetButtonInstallTeam();
            try {
                buttonInstallTeam.ImplicitWaitFindElement();
                if (buttonInstallTeam.IsNull)
                    throw new Exception("Button \"Install Team\" on \"About\" page has got value \"null\".");
                string href = buttonInstallTeam.GetHref();
                string faleName = WorkWithString.GetFileNameFromUrl(href);
                string pathDownload = WorkWithFile.GetDownloadDirectory(ConfigurationManager.PathDownload);
                buttonInstallTeam.Click();
                AppLog.Info("Button \"Install Team\" on \"About\" has got cliked.");
                this.IsFileDownload = WorkWithFile.CheckDownloadFile(pathDownload, faleName,ConfigurationManager.LoopChekingFile,ConfigurationManager.IntervalChekingFile,ConfigurationManager.SizeFile);

            }
            catch (Exception ex) {
                AppLog.Error(ex, "Error has been clicked \"InstallTeam\" button on \"About\"");
            }
        }
        public bool IsFileDownload { get; set; }        
    }
}
