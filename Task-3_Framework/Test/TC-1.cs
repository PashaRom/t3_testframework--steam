using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using App.Framework.Configuration;
using App.ObjectPages;
using App.Framework.WebDriver;
using App.Utilits;

namespace App.Test
{
    [TestFixture]
    class TC_1
    {
        //HomePage homePage;
        //AboutPage aboutPage;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            //homePage = new HomePage();
            //AboutPage aboutPage
        }

        [Test]
        [Category("TC_1")]
        [Order(1)]
        public void OpenMainPage() {
            HomePage homePage = new HomePage();
            Assert.IsTrue(homePage.IsOpen(),"Main page has not opened.");
        }
        [Test]
        [Category("TC_1")]
        [Order(2)]
        public void ClickButtonInstallSteam() {
            HomePage homePage = new HomePage();
            homePage.ClickButtonInstallSteam();
            AboutPage aboutPage = new AboutPage();
            Assert.IsTrue(aboutPage.IsOpen(),"\"About\" page has not been opened.");
            
        }
        [Test]
        [Category("TC_1")]
        [Order(3)]
        public void DownLoadSteamAppFile() {
            // HomePage homePage = new HomePage();
            //homePage.IsOpen();
            AboutPage aboutPage = new AboutPage();
            //WorkWithFile.CheckDownloadDirectory();
            aboutPage.ClickButtonInstallTeam();
            //WorkWithFile.DownLoadFile();
            Assert.IsTrue(aboutPage.IsFileDownload,"The file has not downloaded.");
        }

        //[OneTimeTearDown]
        //public void OneTimeTearDown() {
        //    InstantWebDriver.WebDriver.Close();
        //}
    }
}
