using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using App.Models;

namespace App.TestData.Constants
{
    public struct Locator {
        public const string SpanLogoHolder = ".//span[@id='logo_holder']";
        public const string ButtonInstallSteamHomePage = ".//div[@id='global_action_menu']/div/a";
        public const string ButtonInstalLSteamAboutPage = ".//div[@id='about_greeting']/div[@class='about_install_wrapper']/div[contains(@class, 'about_install')][1]/a[@class='about_install_steam_link']";
        public const string TopMenu = ".//div[@id='store_nav_area']";
        public const string TabTopSellerContent = "//div[@id='tab_content_TopSellers']";
        public const string TopSallerRows = "//div[@id='TopSellersRows']";
        public const string TopSallersRowsItem = "..//a[starts-with(@class,'tab_item')]";
        public const string OriginalPrice = "./div[contains(@class,'discount_block')]/div[@class='discount_prices']/div[@class='discount_original_price']";
        public const string FinalPrice = "./div[contains(@class,'discount_block')]/div[@class='discount_prices']/div[@class='discount_final_price']";
        public const string Discount = "./div[contains(@class,'discount_block')]/div[@class='discount_pct']";
        public const string AppAgegate = "//div[@id='app_agegate']";
        public const string AgeDay = "//select[@id='ageDay']";
        public const string AgeMonth = "//select[@id='ageMonth']";
        public const string AgeYear = "//select[@id='ageYear']";
        public const string ButtonViewPageOnAgeCheck = "//a[contains(@class,'btnv6_blue_hoverfade')][@href='#']";
        public const string GameAreaPurchase = "//div[@id='game_area_purchase']";
        public const string GameAreaPurchaseGameWrapper = "./div[@class='game_area_purchase_game_wrapper'/div[@class='game_area_purchase_game']";
        public const string OriginalPriceGamePage = "./div[@class='game_purchase_action']/div[@class='game_purchase_action_bg'/div[starts-with(@class,'discount_block')]/div[@class='discount_prices']/div[@class='discount_original_price']";
        public const string FinalPriceGamePage = "./div[@class='game_purchase_action']/div[@class='game_purchase_action_bg'/div[starts-with(@class,'discount_block')]/div[@class='discount_prices']/div[@class='discount_final_price']";
        public const string DiscountGamePage = "./div[@class='game_purchase_action']/div[@class='game_purchase_action_bg'/div[starts-with(@class,'discount_block')]/div[@class='discount_pct']";
    }
}
