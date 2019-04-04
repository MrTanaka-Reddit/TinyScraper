using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scraper
{
    public class SessionInfo
    {
        public List<string> SearchHistory { get; set; }
        public string CurrentSearchUrl { get; set; }
        public int MaxHistoryLength { get; set; } = 3;

        public SessionInfo()
        {
            SearchHistory = IO.GetSearchHistoryFromFile();
        }

        /// <summary>
        /// Saves the search history to file
        /// </summary>
        public void SaveSearchHistory()
        {
            if(CurrentSearchUrl != String.Empty)
            {
                if (!SearchHistory.Contains(CurrentSearchUrl))
                {
                    // Add the latest scrape Url to the front of the search history
                    SearchHistory.Insert(0, CurrentSearchUrl);

                    if(SearchHistory.Count <= MaxHistoryLength)
                    {
                        IO.SaveSearchHistoryToFile(SearchHistory.ToArray<string>());
                    } else
                    {
                        // Trim the SearchHistory to the MaxHistory & save it to file
                        string[] trimmedHistory = new string[MaxHistoryLength];
                        SearchHistory.CopyTo(0, trimmedHistory, 0, MaxHistoryLength);
                        IO.SaveSearchHistoryToFile(trimmedHistory);
                    }
                }
            }           
        }

    }
}
