using Newtonsoft.Json;
using log4net;
using System.Reflection;
using System;

namespace Scraper
{
    public static class Serializer
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string Serialize<T>(T input)
        {
            string output = default(string);
            try
            {
                output = JsonConvert.SerializeObject(input);
            }
            catch (Exception ex)
            {
                log.Error("Failed to serialize objects to save");
            }

            return output;
        }

        public static T Deserialize<T>(string input)
        {
            T output = default(T);
            try
            {
                output = JsonConvert.DeserializeObject<T>(input);
            }
            catch(Exception ex)
            {
                log.Error("Failed to deserialize string");

            }

            return output;  
        }
    }
}
