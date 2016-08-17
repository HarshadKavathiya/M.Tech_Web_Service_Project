using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Web.Helpers;
using System.Diagnostics;


namespace WcfService1
{
    public class Service1 : IService1
    {
        public int alexaRankCount(string domain)
        {
            var alexaRank = 0;
            try
            {
                var url = string.Format("http://data.alexa.com/data?cli=10&dat=snbamz&url={0}", domain);

                var doc = System.Xml.Linq.XDocument.Load(url);

                var rank = doc.Descendants("POPULARITY").Select(node => node.Attribute("TEXT").Value).FirstOrDefault();

                if (!int.TryParse(rank, out alexaRank))
                    alexaRank = -1;

            }

            catch (Exception)
            {
                return -1;
            }
            return alexaRank;
        }

        public int GooglePageRankCount(string domain)
        {
            var pageRank = -1;

            //this API_KEY value will expire on 10-5-2015 so again signup and use new API_KEY... 
            var API_KEY = "fDEVbgZ4W2Eqssb5MdfwGD68Fn934SDZkprnmpf8OM7jmW1e29-6t0QiVyzmLfF5";
            var url = "http://www.rankapi.net/";
            var urlParameters = string.Format(url+"api/v1/pagerank.json?key="+API_KEY+"&url="+domain);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
                    HttpWebRequest request = WebRequest.Create(urlParameters.ToString()) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = null;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        json = reader.ReadToEnd();
                    }
                    dynamic data = Json.Decode(json);
                    pageRank = data.rank;
                }
            }
            return pageRank;
        }

 /*       public string Suggestion(string domain)
        {

            var url = "http://suggestqueries.google.com/";
            var urlParameters = string.Format("complete/search?output=firefox&client=firefox&hl=en&q=" + domain);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            return domain;
           }
  */
    }
}