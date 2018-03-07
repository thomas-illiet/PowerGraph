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
            var GetAPI = new Get_API();

            Users UsersResult = GetAPI.ExecuteGet<Users>("v1.0", "users");
            var CacheUsers = UsersResult.value;
            if (!System.String.IsNullOrEmpty(UsersResult.nextLink))
            {
                var tmp = GetAPI.ExecuteGet<Users>(UsersResult.nextLink);
                CacheUsers.AddRange(UsersResult.value);
            }
            WriteObject(CacheUsers);
        }
    }
}
