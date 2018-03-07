using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PowerGraph.Model
{
    public class User
    {
        public String id;
        public String displayName;
        public String givenName;
        public String jobTitle;
        public String mail;
        public String mobilePhone;
        public String officeLocation;
        public String preferredLanguage;
        public String surname;
        public String userPrincipalName;
    }

    public class Users
    {
        [JsonProperty("@odata.context")]
        public string odatacontext;

        [JsonProperty("@odata.nextLink")]
        public string odatalink;

        public List<User> value;
    }
}