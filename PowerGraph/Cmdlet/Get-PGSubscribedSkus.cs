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

            Response<ResponseSubscribedSku> UsersResult = GraphAPI.ExecuteGet<ResponseSubscribedSku>("v1.0", "subscribedSkus");
            WriteObject(UsersResult);
        }
    }
}
