using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PowerGraph.Model
{

    public class SubscribedSku
    {
        public String id;
        public Int16 consumedUnits;
        public String capabilityStatus;
        public String skuIdn;
        public String skuPartNumber;
        public String appliesTo;
        public List<SubscribedSkuPlan> servicePlans;
        //public List<SubscribedSkuPrepaid> prepaidUnits;
        public String displayName
        {
            get
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("POWER_BI_STANDARD",        "Power-BI_Standard");
                dictionary.Add("MCOMEETADV",               "PSTN_conferencing");
                dictionary.Add("EMS",                      "Enterprise_Mobility_Suite");
                dictionary.Add("DESKLESSPACK",             "Office_365_(Plan_K1)");
                dictionary.Add("DESKLESSWOFFPACK",         "Office_365_(Plan_K2)");
                dictionary.Add("LITEPACK",                 "Office_365_(Plan_P1)");
                dictionary.Add("EXCHANGESTANDARD",         "Office_365_Exchange_Online_Only");
                dictionary.Add("STANDARDPACK",             "Office_365_(Plan_E1)");
                dictionary.Add("STANDARDWOFFPACK",         "Office_365_(Plan_E1)");
                dictionary.Add("ENTERPRISEPACK",           "Office_365_(Plan_E3)");
                dictionary.Add("ENTERPRISEWITHSCAL",       "Office_365_(Plan_E4)");
                dictionary.Add("O365_BUSINESS_ESSENTIALS", "Office_365_Business_Essentials");

                if (dictionary.ContainsKey(this.skuPartNumber))
                {
                    return dictionary[this.skuPartNumber];
                }
                else
                {
                    return this.skuPartNumber;
                }
            }
        }
    }
    public class SubscribedSkuPrepaid
    {
        public String enabled;
        public String suspended;
        public String warning;
    }
    public class SubscribedSkuPlan
    {
        public String servicePlanId;
        public String servicePlanName;
        public String provisioningStatus;
        public String appliesTo;
    }

    public class SubscribedSkus
    {
        [JsonProperty("@odata.context")]
        public string context;

        [JsonProperty("@odata.nextLink")]
        public string nextLink;

        public List<SubscribedSku> value;
    }
}
