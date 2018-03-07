using System.Management.Automation;
using PowerGraph.Model;

namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Get, "PGSubscribedSkus")]
    public class Get_PGSubscribedSkus : Cmdlet
    {

        protected override void ProcessRecord()
        {
            var GetAPI = new Get_API();

            SubscribedSkus UsersResult = GetAPI.ExecuteGet<SubscribedSkus>("v1.0", "subscribedSkus");
            var Cache = UsersResult.value;
            var NextLink = UsersResult.nextLink;

            if (!System.String.IsNullOrEmpty(NextLink))
            {
                do
                {
                    SubscribedSkus UsersResultNext = GetAPI.ExecuteGet<SubscribedSkus>(NextLink);
                    Cache.AddRange(UsersResultNext.value);
                    NextLink = UsersResultNext.nextLink;
                } while (NextLink != null);
            }
            WriteObject(Cache);
        }
    }
}
