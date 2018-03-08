using PowerGraph.Model;
using System.Management.Automation;


namespace PowerGraph
{
    [OutputType(typeof(object))]
    [Cmdlet(VerbsCommon.Set, "PGUserLicence")]
    public class Set_PGUserLicence : Cmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0)]
        public string Identity { get; set; }
        protected override void ProcessRecord()
        {
            WriteObject("11");
        }
    }
}
