using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PowerGraph.Model
{
    /// <summary>
    ///
    /// </summary>
    public class UserPasswordProfile
    {
        public String password;
        public bool forceChangePasswordNextSignIn = true;
    }

    /// <summary>
    ///
    /// </summary>
    public class UserCreate
    {
        public UserCreate()
        {
            this.passwordProfile = new UserPasswordProfile();
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
        public UserPasswordProfile passwordProfile;
        public String officeLocation;
        public Int16 postalCode;
        public String preferredLanguage;
        public String state;
        public String streetAddress;
        public String surname;
        public String mobilePhone;
        public String usageLocation;
        public String userPrincipalName;
    }

    /// <summary>
    ///
    /// </summary>
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

    /// <summary>
    ///
    /// </summary>
    public class Users
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<User> value;
    }

    /// <summary>
    ///
    /// </summary>
    public class UserLicencePlan
    {
        public string servicePlanId;
        public string servicePlanName;
        public string provisioningStatus;
        public string appliesTo;
        public string displayName { get { return ConvertLicenceName.Get(this.servicePlanName); } }
    }

    /// <summary>
    ///
    /// </summary>
    public class UserLicence
    {
        public string skuId;
        public string skuPartNumber;
        public List<UserLicencePlan> servicePlans;
        public string displayName { get { return ConvertLicenceName.Get(this.skuPartNumber); } }
    }

    /// <summary>
    ///
    /// </summary>
    public class UserLicences
    {
        [JsonProperty("@odata.context")]
        public string context;
        [JsonProperty("@odata.nextLink")]
        public string nextLink;
        public List<UserLicence> value;
    }
}