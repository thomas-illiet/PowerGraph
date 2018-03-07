using PowerGraph.Model;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Get, "PGUserEvents")]
    public class Get_PGUserEvents : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string Identity { get; set; }
        protected override void ProcessRecord()
        {
            var GetAPI = new Get_API();

            Events UsersResult = GetAPI.ExecuteGet<Events>("v1.0", $"users/{Identity}/events");
            var Cache = UsersResult.value;
            var NextLink = UsersResult.nextLink;

            if (!System.String.IsNullOrEmpty(NextLink))
            {
                do
                {
                    Events UsersResultNext = GetAPI.ExecuteGet<Events>(NextLink);
                    Cache.AddRange(UsersResultNext.value);
                    NextLink = UsersResultNext.nextLink;
                } while (NextLink != null);
            }
            WriteObject(Cache);
        }
    }
}
