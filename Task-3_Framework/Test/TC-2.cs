using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using App.ObjectPages;
using App.Framework.WebDriver;
using App.TestData.Constants;
using App.TestData;
using App.Models;
using OpenQA.Selenium;
using App.Framework.Logging;
using App.TestData.Constants;

namespace App.Test
{
    [TestFixture]
    class TC_2
    {
        public Price Price = new Price();
        [Test(ExpectedResult = true)]
        [Category("TC_2")]
        [Order(1)]
        public bool OpenMainPage()
        {
            HomePage homePage = new HomePage();            
            return homePage.IsOpen();

        }
        [Test(ExpectedResult = true)]
        [Category("TC_2")]
        [Order(2)]
        public bool BrowsingActionPageOpened() {
            HomePage homePage = new HomePage();
            homePage.SelectGamesTopMenu();
            ActionPage actionPage = new ActionPage();
            return actionPage.IsOpen();
        }
        [Test(ExpectedResult = true)]
        [Category("TC_2")]
        [Order(3)]
        public bool OpenTabTopSaller() {
            ActionPage actionPage = new ActionPage();
            actionPage.GetTubMenu(StaticData.TopSaller.Name,StaticData.TopSaller.Locator).OpenTab();
            return actionPage.TabMenu.TabIsOpened();            
        }

        [Test(ExpectedResult = true)]
        [Category("TC_2")]
        [Order(4)]
        public bool CheckSavePrice()
        {
            ActionPage actionPage = new ActionPage();
            Price = actionPage.GetTopBlockSallerRows(By.XPath(Locator.TopSallerRows))
                .GetTopSallerRows(By.XPath(Locator.TopSallersRowsItem))
                .GetTopPrice(By.XPath(Locator.OriginalPrice),By.XPath(Locator.FinalPrice),By.XPath(Locator.Discount));            
            Price.WebElement.Click();
            AgePage agePage = new AgePage();
            if (agePage.IsOpen())
                agePage.EnterCorrectAgeData();
            if (!Price.IsNull) {
                AppLog.Info("The heightest discount price was saved.");
                return true;
            }
            else {
                AppLog.Error("The heightest discount price was not saved.");
                return false;
            }

        }
        /*
        * Step number 5 has not finished.
        * It does not work
         */
        /*
        [Test]
        [Category("TC_2")]
        [Order(5)]
        public void Save() {
            InstantWebDriver.WebDriver.GoToUrl(@"https://store.steampowered.com/app/397540/Borderlands_3/");
            AgePage agePage = new AgePage();
            if (agePage.IsOpen())
                agePage.EnterCorrectAgeData();
            GamePage gamePage = new GamePage();
            gamePage.GetGameAreaPurchase(By.XPath(Locator.GameAreaPurchase))
                .GetPurchasesGame(By.XPath(Locator.GameAreaPurchaseGameWrapper))
                .GetPrice(By.XPath(Locator.OriginalPriceGamePage),By.XPath(Locator.FinalPriceGamePage),By.XPath(Locator.DiscountGamePage));           
            
        }
        */

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            InstantWebDriver.WebDriver.Quit();
        }
    }
}
