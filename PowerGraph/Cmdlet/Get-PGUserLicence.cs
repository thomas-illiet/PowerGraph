using PowerGraph.Model;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Get, "PGUserLicence")]
    public class Get_PGUserLicence : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string Identity { get; set; }
        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();

            Response<ResponseUserLicence> UsersResult = GraphAPI.ExecuteGet<ResponseUserLicence>("v1.0", $"users/{Identity}/licenseDetails");
            WriteObject(UsersResult);
        }
    }
}
