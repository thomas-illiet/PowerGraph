using Newtonsoft.Json;
using PowerGraph.Model;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PowerGraph
{
    public class GraphAPI
    {
        /// <summary>
        ///
        /// </summary>
        public T ExecuteGet<T>(string url)
        {
            var restclient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", string.Format("{0} {1}", New_PGSession.token.token_type.ToString(), New_PGSession.token.access_token.ToString()));
            var tResponse = restclient.Execute(request);
            T result = JsonConvert.DeserializeObject<T>(tResponse.Content);
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        public T ExecuteGet<T>(string version, string method)
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecuteGet<T>(Url);
        }

        /// <summary>
        ///
        /// </summary>
        public object ExecutePost(string url, Object Parameters)
        {
            var restclient = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("{0} {1}", New_PGSession.token.token_type.ToString(), New_PGSession.token.access_token.ToString()));
            request.AddJsonBody(JsonConvert.SerializeObject(Parameters));

            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;

            return JsonConvert.DeserializeObject(tResponse.Content);
        }
    }
}
