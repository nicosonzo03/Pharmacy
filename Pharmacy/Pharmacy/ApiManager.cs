using Newtonsoft.Json;
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
        public static string url = "https://localhost:44361/";
        public static async Task<string> PostAsync(string elencosintomi, string token)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "Disease/" + elencosintomi);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(elencosintomi);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                List<Disease> response = new List<Disease>();
                string result = "";

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

        public IList<Disease> GetDiseases(string text)
        {
            var result = PostAsync(text, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIiwianRpIjoiMmNlMjViYmItZTBkOC00ZWE4LWFmMWItNjMxY2RhNmY1M2NiIiwiZXhwIjoxNjgzMDMwMTA1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjU5OTIxIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwIn0.xKSLPE5urzdevIkQZjqITM5MuLHucyRkTsNHLfMHvq0").Result;

            List<Disease> response = new List<Disease>();

            var k = JsonConvert.DeserializeObject<IList<Results>>(result);
            return ToApiResult(new Result() { Results = k.ToArray() }).Data.ToList();
        }

        ApiResult ToApiResult(Result input)
        {
            var result = new ApiResult();
            result.Data = input.Results.Select(x => new Disease()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToArray();
            return result;
        }

        public class Result
        {
            public Results[] Results { get; set; }
        }

        public class Results
        { 
            public string Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        public class ApiResult
        {
            public Disease[] Data { get; set; }
        }
    }
}