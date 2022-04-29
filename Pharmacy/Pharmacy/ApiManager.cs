using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class ApiManager
    {
        public static string url = "https://localhost:44349/";
        public static async Task<string> PostAsync(string nomeProdotto, string token)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "Products/" + nomeProdotto);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(nomeProdotto);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                List<Disease> response = new List<Disease>();
                string result = "";
                //CreaTelecameraResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    //response = JsonConvert.DeserializeObject<List<Product>>(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
