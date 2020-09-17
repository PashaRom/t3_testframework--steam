using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Elements;
using OpenQA.Selenium;
using App.Framework.Logging;
using App.ObjectPages.Forms;
using App.TestData.Constants;

namespace App.ObjectPages
{
    public class ActionPage
    {
        private TabMenu tabSelling;
        public bool IsOpen() {
            H2 h2 = new H2(By.XPath("//h2[@class='pageheader']"));
                try { 
                h2.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
                if (h2.GetText.Contains("Action")) {
                    AppLog.Info("The \"Action\" page has been opened.");
                    return true;
                }
                else {
                    AppLog.Info("The \"Action\" page has not been opened.");
                    return false;
                }
            }
            catch(Exception ex) {
                AppLog.Fatal(ex,"Fatal Error on \"Action\" page.");
                return false;
            }
        }
        public TabMenu GetTubMenu(string name,string locator) {
            tabSelling = new TabMenu(name,locator);            
            return tabSelling;
        }
        public TabMenu TabMenu {
            get {
                return tabSelling;
            }
        }
        public TopBlockSallerRows GetTopBlockSallerRows(By locator)
        {
            TopBlockSallerRows topBlockSallerRows = new TopBlockSallerRows(locator);
            //BaseElement baseElement = topBlockSallerRows.GetTopSallerRows()
                //topBlockSallerRows.ExplicitWaitExistFindElement(TimeSpan.FromSeconds(5));
                //if (topBlockSallerRows.IsNull)
                //    AppLog.Error($"The element {Locator.TopBlockSallerRows} has not been found.");
                //else
                //    AppLog.Info($"The element {Locator.TopBlockSallerRows} has been found.");
                return topBlockSallerRows;
            //}
        }
        
    }
}
