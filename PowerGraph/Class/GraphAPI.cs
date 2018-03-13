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
        /// Made by Quentin D.
        /// </summary>
        public Response<T> ExecuteGet<T>(string url, bool followNextLink, int maxNextLink)
        {
            Response<T> result = null;
            var restclient = new RestClient();
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", string.Format("{0} {1}", New_PGSession.token.token_type.ToString(), New_PGSession.token.access_token.ToString()));
            string NextLink = string.Empty;
            int count = 0;
            do
            {
                restclient.BaseUrl = (NextLink == string.Empty ? new Uri(url) : new Uri(NextLink));
                var tResponse = restclient.Execute(request);
                Response<T> tmp = JsonConvert.DeserializeObject<Response<T>>(tResponse.Content);
                if (result == null)
                {
                    result = tmp;
                }
                else
                {
                    result.value.AddRange(tmp.value);
                }
                NextLink = tmp.nextLink;
                count++;
            }
            while ((NextLink != null && followNextLink == true) && (count <= maxNextLink || maxNextLink == 0 ));
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        public Response<T> ExecuteGet<T>(string version, string method, bool followNextLink = true, int maxNextLink = 100 )
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecuteGet<T>(Url, followNextLink, maxNextLink);
        }

        /// <summary>
        ///
        /// </summary>
        public T ExecutePost<T>(string url, Object Parameters)
        {
            var restclient = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("{0} {1}", New_PGSession.token.token_type.ToString(), New_PGSession.token.access_token.ToString()));
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var json = request.JsonSerializer.Serialize(Parameters);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            if (tResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                T result = JsonConvert.DeserializeObject<T>(responseJson);
                return result;
            }
            else
            {
                throw new ArgumentException(responseJson);
            }
        }

        public T ExecutePost<T>(string version, string method, Object Parameters)
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecutePost<T>(Url, Parameters);
        }
    }
}
