using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PowerGraph.Model
{

    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++ Add-PGUser
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class RequestUserCreate
    {
        public RequestUserCreate()
        {
            this.passwordProfile = new RequestUserPasswordProfile();
        }

        public bool accountEnabled = true;
        public String city;
        public String country;
        public String department;
        public String displayName;
        public String givenName;
        public String jobTitle;
        public String mailNickname;
        public String passwordPolicies;
        public RequestUserPasswordProfile passwordProfile;
        public String officeLocation;
        //Bug public Int32 postalCode;
        public String preferredLanguage;
        public String state;
        public String streetAddress;
        public String surname;
        public String mobilePhone;
        public String usageLocation;
        public String userPrincipalName;
    }

    public class RequestUserPasswordProfile
    {
        public String password;
        public bool forceChangePasswordNextSignIn = true;
    }

    public class ResponseUserCreate
    {
        public String id;
        //public String businessPhones;
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

    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++ Get-PGUsers
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ResponseUser
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

    public class ResponseUsers
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<ResponseUser> value;
    }

    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++ Get-PGUserLicence
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ResponseUserLicencePlan
    {
        public string servicePlanId;
        public string servicePlanName;
        public string provisioningStatus;
        public string appliesTo;
        public string displayName { get { return ConvertLicenceName.Get(this.servicePlanName); } }
    }

    public class ResponseUserLicence
    {
        public string skuId;
        public string skuPartNumber;
        public List<ResponseUserLicencePlan> servicePlans;
        public string displayName { get { return ConvertLicenceName.Get(this.skuPartNumber); } }
    }

    public class Response<T>
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<T> value;
    }

    public class ResponseUserLicences
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<ResponseUserLicence> value;
    }
}