using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using App.TestData.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using App.Framework.Logging;
using App.Framework.Configuration;
using App.TestData;
using App.Framework.Configuration;

namespace App.ObjectPages
{
    class AgePage
    {
        public bool IsOpen() {
            AppLog.Info("Checking Age page."); 
            Div checkElement = new Div(By.XPath(Locator.AppAgegate));
            checkElement.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if (checkElement.IsNull) {
                AppLog.Info("The Age page has not opened.");
                return false;
            }
            else {
                AppLog.Info("The Age page has opened.");
                return true;
            }

        }

        public void EnterCorrectAgeData() {
            Select day = new Select(By.XPath(Locator.AgeDay));
            day.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if (day.IsNull)
                AppLog.Error($"The day's web element {Locator.AgeDay} has not been founded.");
            else
                AppLog.Info($"The day's web element {Locator.AgeDay} has been founded.");
            try { 
                SelectElement dayOptions = new SelectElement(day.Element);
                dayOptions.SelectByValue(StaticData.Birthday.Day.ToString());
            }
            catch(NoSuchElementException ex) {
                AppLog.Error(ex, "The error has been selected value from Day on AgeCheck page.");
            }

            Select mounth = new Select(By.XPath(Locator.AgeMonth));
            mounth.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if(mounth.IsNull)
                AppLog.Error($"The day's web element {Locator.AgeMonth} has not been founded.");
            else
                AppLog.Info($"The day's web element {Locator.AgeDay} has been founded.");

            try { 
                SelectElement mounthOptions = new SelectElement(mounth.Element);
                mounthOptions.SelectByValue(StaticData.Birthday.Mounth);
            }
            catch(NoSuchElementException ex) {
                AppLog.Error(ex, "The error has been selected value from Mounth on AgeCheck page.");
            }

            Select year = new Select(By.XPath(Locator.AgeYear));
            year.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
            if(year.IsNull)
                AppLog.Error($"The day's web element {Locator.AgeYear} has not been founded.");
            else
                AppLog.Info($"The day's web element {Locator.AgeDay} has been founded.");
            try { 
                SelectElement yearOptions = new SelectElement(year.Element);
                yearOptions.SelectByValue(StaticData.Birthday.Year.ToString());
            }
            catch(NoSuchElementException ex) {
                AppLog.Error(ex, "The error has been selected value from Year on AgeCheck page.");
            }
            try { 
                Button viewPage = new Button(By.XPath(Locator.ButtonViewPageOnAgeCheck));
                viewPage.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
                viewPage.Click();
            }
            catch(NoSuchElementException ex) {
                AppLog.Error(ex, "The error appeared during runtime to click on the button \"View Page\" on AgeCheck page.");
            }
        }
    }
}
