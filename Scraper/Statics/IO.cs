using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
