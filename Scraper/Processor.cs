using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Globalization;
using System.IO;
using log4net;
using System.Reflection;
using System.Net;

namespace Scraper
{
    public static class Processor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Gets all links in anchor tags in a HTML document
        /// </summary>
        /// <param name="document">An Html document</param>
        /// <param name="baseUrl">The Url the Html document was downloaded from</param>
        /// <returns></returns>
        public static List<string> GetUrls(HtmlDocument document, string baseUrl)
        {
            var urls = new List<string>();

            // If the document's root node is null, or if there's no <a> tags in the document,
            // then return null.
            if (document.DocumentNode == null) return null;
            var anchors = document.DocumentNode.SelectNodes("//a");
            if (anchors == null) return null;

            // Loop through each <a> tag in the document and get the href attribute's value.
            foreach (var anchor in anchors)
            {
                if (anchor.Attributes["href"] != null)
                {
                    Uri uri;

                    // Add any Urls that should be ignored here.
                    // E.g. One web server included a link back to the root site on each page.
                    string[] illegalUrls = { "/" };

                    var value = anchor.Attributes["href"].Value;

                    if (value.StartsWith("http://",true, CultureInfo.CurrentCulture) ||
                        value.StartsWith("https://", true, CultureInfo.CurrentCulture))
                    {
                        // If the Url is already absolute, then just use it
                        Uri.TryCreate(value, UriKind.Absolute, out uri); 
                    }
                    else
                    {
                        // If the Url is relative, then manually create an absolute Url
                        Uri.TryCreate(String.Concat(baseUrl, value), UriKind.Absolute, out uri);
                    }

                    // Don't add urls with queries, because that can lead to
                    // infinite scraping if they loop back on themselves.
                    if(uri != null)
                    {
                        if (uri.Query == "" && !illegalUrls.Contains(value))
                        {
                            urls.Add(uri.OriginalString);
                        }
                    } else
                    {
                        log.Warn($"Failed to process {value}, in HTML document: {baseUrl}");
                    }    
                }
            }
            return urls;
        }

        /// <summary>
        /// Returns only the Urls that point to files, not the ones that point to other HTML documents
        /// </summary>
        /// <param name="urls">A list of absolute Urls</param>
        /// <returns></returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static List<string> GetFileUrls(List<string> urls)
        {
            if (urls == null) return null;

            var fileUrls = new List<string>();

            // Iterate through each url and get the last segment
            // If the segment contains a '.', then assume it's a file.
            // Todo: This is a crap way to check if it's a file. Consider using the header as someone suggested.
            foreach(var url in urls)
            {
                var uri = new Uri(url);
                var lastSegment = uri.AbsolutePath.Split('/').Last();
                if (lastSegment.Contains("."))
                {
                    fileUrls.Add(url);
                }
            }

            return fileUrls;
        }

        /// <summary>
        /// Returns all Urls that are links to other folders, in the same domain as the baseUrl,
        /// and don't point up the directory tree.
        /// </summary>
        /// <param name="urls">The list of Urls to process</param>
        /// <param name="baseUrl">The domain that all selected folders should belong to</param>
        /// <returns>List of Urls representing downstream folders</returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static List<string> GetOnlyDownstreamFolders(List<string> urls, string baseUrl)
        {
            var result = GetNonFileUrls(urls);
            result = GetLocalFolders(result, baseUrl);
            result = RemoveUpstreamPaths(result, baseUrl);

            return result;
        }

        /// <summary>
        /// Returns a new list of Urls, containing only those that don't point to files.
        /// </summary>
        /// <param name="urls">A list of Urls to process</param>
        /// <returns>Returns a new list of Url strings</returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static List<string> GetNonFileUrls(List<string> urls)
        {
            var nonFileUrls = new List<string>();

            foreach (var url in urls)
            {
                var uri = new Uri(url);
                var lastSegment = uri.AbsolutePath.Split('/').Last();

                // Todo: This is a crap way to check if it's a folder. Consider using the header as someone suggested.
                if (!lastSegment.Contains("."))
                {
                    nonFileUrls.Add(url);
                }
            }

            return nonFileUrls;
        }

        /// <summary>
        /// Returns a list of Urls, containing only Urls in the root domain of the baseUrl
        /// </summary>
        /// <param name="urls">The list of Urls to be processed</param>
        /// <param name="baseUrl">The root domain Url</param>
        /// <returns>A list of Urls within the baseUrl domain</returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static List<string> GetLocalFolders(List<string> urls, string baseUrl)
        {
            var localFolders = new List<string>();
            var domainRoot = new Uri(baseUrl).Authority;

            foreach (var url in urls)
            {
                var urlRoot = new Uri(url).Authority;
                if (urlRoot == domainRoot)
                {
                    localFolders.Add(url);
                }
            }

            return localFolders;
        }

        /// <summary>
        /// Remvoves Urls that might be pointing back up the folder structure
        /// </summary>
        /// <param name="urls">A list of absolute Urls</param>
        /// <param name="baseUrl">The url containing the domain all other Urls should be within</param>
        /// <returns>List of Urls within the baseUrl's domain</returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static List<string> RemoveUpstreamPaths(List<string> urls, string baseUrl)
        {
            var downstreamPaths = new List<string>();
            foreach (var url in urls)
            {
                if (!url.Contains("/../") && !baseUrl.Contains(url))
                {
                    downstreamPaths.Add(url);
                }
            }

            return downstreamPaths;
        }

        /// <summary>
        /// Retrieves the file portion of a Url, UrlDecodes it, then returns it
        /// </summary>
        /// <param name="url">The absolute Url path to the file </param>
        /// <returns>Url decoded file name</returns>
        /// <remarks>All input urls are assumed to be valid and absolute Urls</remarks>
        public static string CleanseName(string url)
        {
            Uri uri = new Uri(url);

            var fileName = Path.GetFileName(uri.LocalPath);

            return WebUtility.UrlDecode(fileName);
        }

        public static List<string> GetFilesForGivenExtensions(List<string> files, string[] extensions)
        {
            var filteredList = new List<string>();

            foreach (var url in files)
            {
                foreach (var extension in extensions)
                {
                    if (url.EndsWith(extension))
                    {
                        filteredList.Add(url);
                        break;
                    }
                }
            }
            return filteredList;
        }

        public static string GetTimeDifference(DateTime start, DateTime end)
        {
            return (end - start).Seconds.ToString();
        }

        public static string EnsureSlash(string url)
        {
            if (url.EndsWith("/"))
            {
                return url;
            }
            else
            {
                return url + '/';
            }
        }

    }
}
