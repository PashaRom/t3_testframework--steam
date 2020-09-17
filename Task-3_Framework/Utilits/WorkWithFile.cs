using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using App.Framework.Logging;
using System.Net.Http;
using System.Threading;

namespace App.Utilits
{
    public static class WorkWithFile
    {
        public static async void DownLoadFile() {
            try {
                string currentDirectory = Directory.GetCurrentDirectory();
                string downloadDirectoryName = @"\Download";
                string downloadFullPathDirectory = $"{currentDirectory}{downloadDirectoryName}";
                if (Directory.Exists(downloadFullPathDirectory)) {
                    AppLog.Info($"That path {downloadFullPathDirectory} exists already.");                    
                }
                else { 
                    DirectoryInfo downloadingDirectory = Directory.CreateDirectory(downloadFullPathDirectory);
                    AppLog.Info($"The directory has been created successfully at {downloadFullPathDirectory}.");
                }

                HttpClient client = new HttpClient();
                string webAddress = @"https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe";
                HttpResponseMessage response = await client.GetAsync(webAddress);
                response.EnsureSuccessStatusCode();
                string downloadPath = $"{downloadFullPathDirectory}\\SteamSetup.exe";

                FileStream fileStream = null;

                using (fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    await response.Content.CopyToAsync(fileStream);
                }
                    //return content.CopyToAsync(fileStream).ContinueWith(
                    //    (copyTask) =>
                    //    {
                    //        fileStream.Close();
                    //    });
               
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }

                    
            }
            catch (Exception ex) {
                AppLog.Fatal(ex, "Error has been Download file");
            }
        }
        public static string CheckDownloadDirectory(string path) {
            string pathDownload = null;
            try {
                //if (path == null)
                //    pathDownload = Directory.GetCurrentDirectory();
                pathDownload = WorkWithFile.GetDownloadDirectory(path);//Path.GetFullPath(path);               
                if (Directory.Exists(pathDownload))
                {
                    AppLog.Info($"That path {pathDownload} exists already.");
                }
                else
                {
                    DirectoryInfo downloadingDirectory = Directory.CreateDirectory(pathDownload);
                    AppLog.Info($"The directory has been created successfully at {pathDownload}.");
                }
                return pathDownload;
            }
            catch (Exception ex) {
                AppLog.Fatal(ex, "Error has been check directory.");
                return pathDownload;
            }
        }

        public static string GetDownloadDirectory(string path) {
            string pathDownload = null;
            if (path == null)
                pathDownload = Directory.GetCurrentDirectory();
            pathDownload = Path.GetFullPath(path);
            return pathDownload;
        }

        public static bool CheckDownloadFile(string path, string fileName, int loop, int interval, int sizeFile) {
            try {
                string fullPath = $"{path}\\{fileName}";               
                //int sizeFile = 1573568;
                Thread.Sleep(interval);
                for(int i = 0; i < loop; i++) {
                    FileInfo fileInfo = new FileInfo(fullPath);
                    if (File.Exists(fullPath)) { 
                        if (fileInfo.Length >= sizeFile) {
                            AppLog.Info($"File {fullPath} has been downloaded successful.");
                            return true;                            
                        }
                        else
                            Thread.Sleep(interval);
                    }                   
                    else 
                        Thread.Sleep(interval);                    
                }
                AppLog.Error($"File {fullPath} has not been downloaded.");
                return false;
            }
            catch(Exception ex) {
                AppLog.Fatal(ex, "Error has been check directory.");
                return false;
            }
        }
    }
}
