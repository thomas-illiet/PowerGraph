using PowerGraph.Model;
using System.Collections.Generic;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Add, "PGUser")]
    public class Add_PGUser : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, Position = 0)]
        public string userPrincipalName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, Position = 1)]
        public string password { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, Position = 2)]
        public string displayName { get; set; }
        protected override void ProcessRecord()
        {

            UserCreate user = new UserCreate();
            user.userPrincipalName = "peon@thomas-illiet.fr";
            user.displayName = "Peon Man";
            user.passwordProfile.password = "B3stP30n1tsM3!";
            user.jobTitle = "Peon";

            WriteObject(user);

            var GraphAPI = new GraphAPI();
            GraphAPI.ExecutePost("https://graph.microsoft.com/v1.0/users", user);
        }
    }
}