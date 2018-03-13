using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerGraph.Model
{
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class RequestAssignLicense
    {
        public Array addLicenses;
        public Array removeLicenses;
    }

    public class ResponseAssignLicense
    {
        public String addLicenses;
        public List<ResponseAssignedLicenses> assignedLicenses;
        public List<ResponseAssignedPlans> assignedPlans;
        public String city;
        public String companyName;
    }

    public class ResponseAssignedLicenses
    {
        public Array disabledPlans;
        public String skuId;
    }

    public class ResponseAssignedPlans
    {
        public String assignedDateTime;
        public String capabilityStatus;
        public String service;
        public String servicePlanId;
    }
}
