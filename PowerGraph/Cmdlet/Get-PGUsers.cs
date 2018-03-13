﻿using PowerGraph.Model;
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
            var result = GraphAPI.ExecuteGet<ResponseUser>("v1.0","users/delta");
            WriteObject(result);
        }
    }
}
