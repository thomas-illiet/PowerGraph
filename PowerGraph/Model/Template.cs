using Newtonsoft.Json;
using System.Collections.Generic;

namespace PowerGraph.Model
{

    public class Response<T>
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<T> value;
    }
}
