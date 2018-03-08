using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PowerGraph.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SubscribedSku
    {
        public String id;
        public Int16 consumedUnits;
        public String capabilityStatus;
        public String skuId;
        public String skuPartNumber;
        public String appliesTo;
        public List<SubscribedSkuPlan> servicePlans;
        public SubscribedSkuPrepaid prepaidUnits;
        public String displayName { get { return ConvertLicenceName.Get(this.skuPartNumber); } }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SubscribedSkuPrepaid
    {
        public String enabled;
        public String suspended;
        public String warning;
    }

    /// <summary>
    /// 
    /// </summary>
    public class SubscribedSkuPlan
    {
        public String servicePlanId;
        public String servicePlanName;
        public String provisioningStatus;
        public String appliesTo;
        public String displayName { get { return ConvertLicenceName.Get(this.servicePlanName); } }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SubscribedSkus
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<SubscribedSku> value;
    }
}
