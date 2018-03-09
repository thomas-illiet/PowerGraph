﻿using System.Collections.Generic;


namespace PowerGraph
{
    static class ConvertLicenceName
    {
        static Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            {"POWER_BI_STANDARD", "BI_Standard"},
            {"MCOMEETADV", "PSTN_conferencing"},
            {"EMS", "Enterprise_Mobility_Suite"},
            {"DESKLESSPACK", "Office_365_(Plan_K1)"},
            {"DESKLESSWOFFPACK", "Office_365_(Plan_K2)"},
            {"LITEPACK", "Office_365_(Plan_P1)"},
            {"EXCHANGESTANDARD", "Office_365_Exchange_Online_Only"},
            {"STANDARDPACK", "Office_365_(Plan_E1)"},
            {"STANDARDWOFFPACK", "Office_365_(Plan_E1)"},
            {"ENTERPRISEPACK", "Office_365_(Plan_E3)"},
            {"ENTERPRISEWITHSCAL", "Office_365_(Plan_E4)"},
            {"O365_BUSINESS_ESSENTIALS", "Office_365_Business_Essentials"}
        };

        public static string Get(string word)
        {
            string result;
            if (_dict.TryGetValue(word, out result))
            {
                return result;
            }
            else
            {
                return word;
            }
        }

    }
}