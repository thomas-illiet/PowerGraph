using PowerGraph.Model;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(ResponseUserLicence))]
    [Cmdlet(VerbsCommon.Get, "PGUserLicence")]
    public class Get_PGUserLicence : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "userPrincipalName", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string userPrincipalName { get; set; }

        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();
            WriteObject(GraphAPI.ExecuteGetAll<ResponseUserLicence>("v1.0", $"users/{userPrincipalName}/licenseDetails").value, true);
        }
    }
}
