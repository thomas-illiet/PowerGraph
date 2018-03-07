using Newtonsoft.Json;

namespace PowerGraph.Model
{
    class Metadata
    {
        [JsonProperty("@odata.context")]
        public string odatacontext;
        [JsonProperty("@odata.nextLink")]
        public string odatanextLink;
    }
}
