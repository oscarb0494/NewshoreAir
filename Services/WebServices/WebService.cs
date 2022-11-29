using NLog;
using NLog.Fluent;
using RestSharp;
using Services.IWebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.WebServices
{
    public class WebService : IWebService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string GetHTTPService(string url)
        {

            var response = string.Empty;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Content-Type", "application/json");
                RestResponse result = client.Execute(request);

                if (result.IsSuccessStatusCode)
                {
                    return result.Content;
                }

            }catch(Exception ex)
            {
                logger.Info($"Error while trying send Request with Server API ::Exception {JsonConvert.SerializeObject(ex)} ::URL {JsonConvert.SerializeObject(url)}");

            }
            return response;
        }
    }
}
