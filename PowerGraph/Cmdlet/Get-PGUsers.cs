using PowerGraph.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Get, "PGUsers")]
    public class Get_PGUsers : Cmdlet
    {
        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();

            Users UsersResult = GraphAPI.ExecuteGet<Users>("v1.0", "users");
            var CacheUsers = UsersResult.value;
            if (!System.String.IsNullOrEmpty(UsersResult.nextLink))
            {
                var tmp = GraphAPI.ExecuteGet<Users>(UsersResult.nextLink);
                CacheUsers.AddRange(UsersResult.value);
            }
            WriteObject(CacheUsers);
        }
    }
}
