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

            ResponseUserLicences UsersResult = GraphAPI.ExecuteGet<ResponseUserLicences>("v1.0", $"users/{Identity}/licenseDetails");
            var Cache = UsersResult.value;
            var NextLink = UsersResult.nextLink;

            if (!System.String.IsNullOrEmpty(NextLink))
            {
                do
                {
                    ResponseUserLicences UsersResultNext = GraphAPI.ExecuteGet<ResponseUserLicences>(NextLink);
                    Cache.AddRange(UsersResultNext.value);
                    NextLink = UsersResultNext.nextLink;
                } while (NextLink != null);
            }
            WriteObject(Cache);
        }
    }
}
