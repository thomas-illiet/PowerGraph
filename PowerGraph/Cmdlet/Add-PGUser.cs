using PowerGraph.Model;
using System.Management.Automation;

namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Add, "PGUser")]
    public class Add_PGUser : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string UserPrincipalName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 1)]
        public string Password { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 2)]
        public string DisplayName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 3)]
        public string MailNickname { get; set; }

        protected override void ProcessRecord()
        {
            // Parameters
            RequestUserCreate user = new RequestUserCreate();
            user.userPrincipalName = UserPrincipalName;
            user.displayName = DisplayName;
            user.passwordProfile.password = Password;
            user.mailNickname = MailNickname;

            // Create User
            var GraphAPI = new GraphAPI();
            ResponseUserCreate Request = GraphAPI.ExecutePost<ResponseUserCreate>("https://graph.microsoft.com/v1.0/users", user);
            WriteObject(Request);
        }
    }
}