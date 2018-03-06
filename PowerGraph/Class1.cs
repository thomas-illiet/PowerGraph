
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Management.Automation;


namespace PowerGraph
{

    /// ++++++++++++++++++++++++++++++++++++++++++++++++
    /// + New-PGSession
    /// ++++++++++++++++++++++++++++++++++++++++++++++++
	[OutputType(typeof(string))]
    [Cmdlet(VerbsCommon.New, "PGSession")]
    public class GetToken : Cmdlet
    {

        /// ###########################
        /// # Parameter
        /// ###########################
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string ClientID { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 1)]
        public string ClientSecret { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 2)]
        public string TenantID { get; set; }

        /// ###########################
        /// # Script
        /// ###########################
        protected override void ProcessRecord()
        {
            // Constants
            var resource = $"https://login.microsoftonline.com/{TenantID}/oauth2/token";
            var scope = "https://graph.microsoft.com/.default";

            // request token
            var restclient = new RestClient(resource);
            var request = new RestRequest(Method.POST);
            request.AddParameter("client_id", ClientID);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", scope);

            // execute the request
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;

            // get token
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            WriteObject(token);
        }
    }
}
