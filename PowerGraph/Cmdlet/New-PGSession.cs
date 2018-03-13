using RestSharp;
using System.Management.Automation;

namespace PowerGraph
{

    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.New, "PGSession")]
    public class New_PGSession : Cmdlet
    {

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string ClientID { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 1)]
        public string ClientSecret { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 2)]
        public string TenantID { get; set; }

        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();
            GraphAPI.Connect(ClientID, ClientSecret, TenantID);
        }
    }
}
