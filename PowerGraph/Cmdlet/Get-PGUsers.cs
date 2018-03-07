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
            var GetAPI = new GetAPI();

            Users UsersResult = GetAPI.Execute<Users>("v1.0", "users");
            var CacheUsers = UsersResult.value;
            if (!System.String.IsNullOrEmpty(UsersResult.odatalink))
            {
                var tmp = GetAPI.Execute<Users>(UsersResult.odatalink);
                CacheUsers.AddRange(UsersResult.value);
            }
            WriteObject(CacheUsers);
        }
    }
}
