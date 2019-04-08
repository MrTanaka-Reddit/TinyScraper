using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scraper
{
    internal static class IO
    {
        internal static void SaveSearchHistoryToFile(string[] searchHistory)
        {
            // If the history file doesn't exist, then create it
            File.WriteAllLines(Constants.HISTORY_FILEPATH, searchHistory);
        }

        internal static List<string> GetSearchHistoryFromFile()
        {
            try
            {
                var history = File.ReadAllLines("history.txt");
                if (history.Length > 0)
                {
                    return history.ToList<string>();
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (FileNotFoundException ex)
            {
                // log error

                // return empty
                return new List<string>();
            }
        }

        internal static void SaveScrapeFile(string contents)
        {
            var folderPath = EnsureFolder(Constants.SCRAPEFILE_FOLDER);
            var fileName = Guid.NewGuid().ToString();
            File.WriteAllText(folderPath + "\\" + fileName, contents);
        }

        internal static List<ScrapeFileInfo> LoadScrapeFiles(string folderPath)
        {
            var scrapeFilesInfo = new List<ScrapeFileInfo>();
            EnsureFolder(folderPath);

            var files = Directory.GetFiles(Application.StartupPath + "\\" + folderPath);
            foreach(var filePath in files)
            {
                var url = File.ReadLines(filePath).FirstOrDefault();
                scrapeFilesInfo.Add(new ScrapeFileInfo{
                    FilePath = filePath,
                    Url = url
                });    
            }

            return scrapeFilesInfo;
        }

        private static string EnsureFolder(string folderPath)
        {
            if (!Directory.Exists(Application.StartupPath + folderPath))
            {
                return Directory.CreateDirectory(folderPath).FullName;
            }
            else
            {
                return Directory.GetDirectories(Application.StartupPath + folderPath).FirstOrDefault();
            }
        }

    }
}
