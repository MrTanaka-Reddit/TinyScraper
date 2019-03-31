using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HtmlAgilityPack;
using log4net;
using System.Reflection;

namespace Scraper
{
    public class Downloader
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<HtmlDocument> GetDocument(string url)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();

            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    //Accept all server certificate
                    ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        {
                            return true;
                        };

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    doc.LoadHtml(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    log.Warn($"Unable to download: {url}");
                    return null;
                }
            }

            return doc;
        }
    }
}
