using Newtonsoft.Json;
using PowerGraph.Model;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PowerGraph
{
    /// ++++++++++++++++++++++++++++++++++++++++++++++++
    /// + Class GetAPI
    /// ++++++++++++++++++++++++++++++++++++++++++++++++
    public class GetAPI
    {
        public T Execute<T>(string Url)
        {
            Console.WriteLine(Url);
            var restclient = new RestClient(Url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", string.Format("{0} {1}", NewPGSession.token.token_type.ToString(), NewPGSession.token.access_token.ToString()));
            var tResponse = restclient.Execute(request);
            T result = JsonConvert.DeserializeObject<T>(tResponse.Content);
            return result;
        }

        public T Execute<T>(string version, string method)
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return Execute<T>(Url);
        }
    }
}
