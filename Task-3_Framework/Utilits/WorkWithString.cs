using System;
using System.Collections.Generic;
using System.Text;
using App.Framework.Logging;

namespace App.Utilits
{
    public static class WorkWithString
    {
        public static string GetFileNameFromUrl(string url) {
            try
            {
                if (String.IsNullOrEmpty(url)){
                    AppLog.Error("Can not parse url because that has value null");
                    return null;
                }
                string[] arrUrl = url.Split('/');
                return arrUrl[arrUrl.Length - 1];
            }
            catch (Exception ex) {
                AppLog.Fatal(ex, "Error has been got GetFileNameFromUrl.");
                return null;
            }
        }
    }
}
