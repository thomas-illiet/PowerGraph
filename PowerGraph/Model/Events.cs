using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PowerGraph.Model
{
    public class Event
    {
        public String id;
        public String subject;
        public String bodyPreview;
    }

    public class Events
    {
        [JsonProperty("@odata.context")]
        public string context;

        [JsonProperty("@odata.nextLink")]
        public string nextLink;

        public List<Event> value;
    }
}