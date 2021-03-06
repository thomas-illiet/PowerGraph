﻿using PowerGraph.Model;
using System.Management.Automation;

namespace PowerGraph
{
    [OutputType(typeof(ResponseUser))]
    [Cmdlet(VerbsCommon.Get, "PGUsers")]
    public class Get_PGUsers : Cmdlet
    {
        protected override void ProcessRecord()
        {
            var GraphAPI = new GraphAPI();
            WriteObject(GraphAPI.ExecuteGetAll<ResponseUser>("v1.0", "users").value, true);
        }

    }
}
