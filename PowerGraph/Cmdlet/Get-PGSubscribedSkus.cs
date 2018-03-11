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
            var GraphAPI = new GraphAPI();

            ResponseSubscribedSkus UsersResult = GraphAPI.ExecuteGet<ResponseSubscribedSkus>("v1.0", "subscribedSkus");
            var Cache = UsersResult.value;
            var NextLink = UsersResult.nextLink;

            if (!System.String.IsNullOrEmpty(NextLink))
            {
                do
                {
                    ResponseSubscribedSkus UsersResultNext = GraphAPI.ExecuteGet<ResponseSubscribedSkus>(NextLink);
                    Cache.AddRange(UsersResultNext.value);
                    NextLink = UsersResultNext.nextLink;
                } while (NextLink != null);
            }
            WriteObject(Cache);
        }
    }
}
