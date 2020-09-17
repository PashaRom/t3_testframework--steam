using System;
using System.Collections.Generic;
using System.Text;
using App.Models;

namespace App.TestData
{
    public static class StaticData
    {
        public static MenuItem BrowseMenuItem = new MenuItem("Browse", ".//div[@class='store_nav_bg']/div[@class='store_nav']/div[contains(@class, 'tab')]");
        public static MenuItem ActionSubMenuItem = new MenuItem("Action", ".//div[@id='genre_flyout']/div[@class='popup_body popup_menu_twocol']/div[@class='popup_menu']/a[@class='popup_menu_item']");
        public static TabItem TopSaller = new TabItem("Top Sallers", "//div[@id='tab_select_TopSellers']");
        
        public static Birthday Birthday = new Birthday(9, "February",1981);
        
        
    }
}
