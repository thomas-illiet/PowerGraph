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
