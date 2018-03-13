using Newtonsoft.Json;
using PowerGraph.Model;
using RestSharp;
using System;

namespace PowerGraph
{
    public class GraphAPI
    {

        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++ Connect to GraphAPI
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static ResponseToken token { get; set; }
        public bool Connect(string ClientID, string ClientSecret, string TenantID)
        {
            try
            {
                // Constants
                var resource = $"https://login.microsoftonline.com/{TenantID}/oauth2/v2.0/token";
                var scope = "https://graph.microsoft.com/.default";


                // Request token
                var restclient = new RestClient(resource);
                var request = new RestRequest(Method.POST);
                request.AddParameter("client_id", ClientID);
                request.AddParameter("client_secret", ClientSecret);
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("scope", scope);

                // Execute the request
                var Response = restclient.Execute(request);

                if (Response.ErrorException != null)
                {
                    const string message = "Error retrieving response. Check inner details for more info.";
                    var ApplicationException = new ApplicationException(message, Response.ErrorException);
                    throw ApplicationException;
                }

                var responseJson = Response.Content;
                var responseToken = JsonConvert.DeserializeObject<ResponseToken>(responseJson);

                if (responseToken.access_token != null)
                {
                    // Store token information
                    token = JsonConvert.DeserializeObject<ResponseToken>(responseJson);
                    return true;
                }
                else
                {
                    const string message = "Unable to connect to Graph API Microsoft. Please check your credential";
                    var ApplicationException = new ApplicationException(message);
                    throw ApplicationException;
                }
            }
            catch (Exception e)
            {
                const string message = "Error connect to Graph API Microsoft. Check inner details for more info.";
                var ApplicationException = new ApplicationException(message, e);
                throw ApplicationException;
            }
        }

        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++ Check Session
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool CheckSession()
        {

            if (!object.ReferenceEquals(token, null))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++ GET ROW
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public T ExecuteGetRow<T>(string url)
        {
            if (CheckSession() == true)
            {
                try
                {
                    var restclient = new RestClient(url);
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    request.AddHeader("Authorization", string.Format("{0} {1}", token.token_type.ToString(), token.access_token.ToString()));
                    var Response = restclient.Execute(request);

                    if (Response.ErrorException != null)
                    {
                        const string message = "Error retrieving response. Check inner details for more info.";
                        var ApplicationException = new ApplicationException(message, Response.ErrorException);
                        throw ApplicationException;
                    }

                    T result = JsonConvert.DeserializeObject<T>(Response.Content);
                    return result;
                }
                catch (Exception e)
                {
                    const string message = "Error retrieving response. Check inner details for more info.";
                    var ApplicationException = new ApplicationException(message, e);
                    throw ApplicationException;
                }
            }
            else
            {
                var ApplicationException = new ApplicationException("Please connect before execute this command.");
                throw ApplicationException;
            }
        }

        public T ExecuteGetRow<T>(string version, string method)
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecuteGetRow<T>(Url);
        }

        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++ GET ALL
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Response<T> ExecuteGetAll<T>(string url, bool followNextLink, int maxNextLink)
        {
            if (CheckSession() == true)
            {
                try
                {
                    Response<T> result = null;
                    var restclient = new RestClient();
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    request.AddHeader("Authorization", string.Format("{0} {1}", token.token_type.ToString(), token.access_token.ToString()));
                    string NextLink = string.Empty;
                    int count = 0;
                    do
                    {
                        restclient.BaseUrl = (NextLink == string.Empty ? new Uri(url) : new Uri(NextLink));
                        var Response = restclient.Execute(request);

                        if (Response.ErrorException != null)
                        {
                            const string message = "Error retrieving response. Check inner details for more info.";
                            var ApplicationException = new ApplicationException(message, Response.ErrorException);
                            throw ApplicationException;
                        }

                        Response<T> tmp = JsonConvert.DeserializeObject<Response<T>>(Response.Content);
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
                catch (Exception e)
                {
                    const string message = "Error retrieving response. Check inner details for more info.";
                    var ApplicationException = new ApplicationException(message, e);
                    throw ApplicationException;
                }
            }
            else
            {
                var ApplicationException = new ApplicationException("Please connect before execute this command.");
                throw ApplicationException;
            }
        }

        public Response<T> ExecuteGetAll<T>(string version, string method, bool followNextLink = true, int maxNextLink = 100 )
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecuteGetAll<T>(Url, followNextLink, maxNextLink);
        }

        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++ POST
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public T ExecutePost<T>(string url, Object Parameters)
        {
            if (CheckSession() == true)
            {
                var restclient = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("{0} {1}", token.token_type.ToString(), token.access_token.ToString()));
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
            else
            {
                var ApplicationException = new ApplicationException("Please connect before execute this command.");
                throw ApplicationException;
            }
        }

        public T ExecutePost<T>(string version, string method, Object Parameters)
        {
            var Url = string.Format("https://graph.microsoft.com/{0}/{1}", version, method);
            return ExecutePost<T>(Url, Parameters);
        }
    }
}
