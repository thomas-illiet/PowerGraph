using PowerGraph.Model;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Remove, "PGUser")]
    public class Remove_PGUser : Cmdlet
    {

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string Identity { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, Position = 0)]
        public bool Force { get; set; }

        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();

            // User Exist ?
            var User = GraphAPI.ExecuteGetRow<ResponseUserCreate>("v1.0", $"use9rs/{Identity}");
            if (!System.String.IsNullOrEmpty(User.id))
            {
                return;
            }
                WriteObject(User.id);
        }
    }
}
