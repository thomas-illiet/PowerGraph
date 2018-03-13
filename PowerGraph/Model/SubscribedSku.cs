using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PowerGraph.Model
{
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++ Get-PGSubscribedSkus
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ResponseSubscribedSku
    {
        public String id;
        public Int16 consumedUnits;
        public String capabilityStatus;
        public String skuId;
        public String skuPartNumber;
        public String appliesTo;
        public List<ResponseSubscribedSkuPlan> servicePlans;
        public ResponseSubscribedSkuPrepaid prepaidUnits;
        public String displayName { get { return ConvertLicenceName.Get(this.skuPartNumber); } }
    }

    public class ResponseSubscribedSkuPrepaid
    {
        public String enabled;
        public String suspended;
        public String warning;
    }

    public class ResponseSubscribedSkuPlan
    {
        public String servicePlanId;
        public String servicePlanName;
        public String provisioningStatus;
        public String appliesTo;
        public String displayName { get { return ConvertLicenceName.Get(this.servicePlanName); } }
    }


}
