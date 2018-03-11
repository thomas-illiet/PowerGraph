using Newtonsoft.Json;
using PowerGraph.Model;
using RestSharp;
using System.Management.Automation;

namespace PowerGraph
{

    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.New, "PGSession")]
    public class New_PGSession : Cmdlet
    {
        /// Variable
        public static ResponseToken token { get; set; }

        /// Parameter
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string ClientID { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 1)]
        public string ClientSecret { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 2)]
        public string TenantID { get; set; }

        /// Script
        protected override void ProcessRecord()
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
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;

            // Store token information
            token = JsonConvert.DeserializeObject<ResponseToken>(responseJson);
        }

    }

}
