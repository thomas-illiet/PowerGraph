﻿using System.Collections.Generic;

namespace PowerGraph
{
    static class ConvertLicenceName
    {

        static Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            {"TEAMS1",                               "Microsoft Teams"},
            {"AAD_PREMIUM",                          "Azure Active Directory Premium P1"},
            {"AAD_PREMIUM_P2",                       "Azure Active Directory Premium P2"},
            {"RMS_S_ENTERPRISE",                     "Azure Active Directory Rights Management"},
            {"RIGHTSMANAGEMENT_ADHOC",               "Azure Rights Management Services Ad-hoc"},
            {"CRMPLAN2",                             "Dynamics CRM Online Plan 2"},
            {"EMS",                                  "Enterprise Mobility + Security E3"},
            {"EMSPREMIUM",                           "Enterprise Mobility + Security E5"},
            {"ENTERPRISEPACK_B_PILOT",               "ENTERPRISEPACK_B_PILOT"},
            {"EXCHANGEENTERPRISE_FACULTY",           "Exch Online Plan 2 for Faculty"},
            {"EXCHANGE_L_STANDARD",                  "Exchange Online (Plan 1)"},
            {"EXCHANGE_S_STANDARD",                  "Exchange Online (Plan 2)"},
            {"ATP_ENTERPRISE_FACULTY",               "Exchange Online Advanced Threat Protection"},
            {"ATP_ENTERPRISE",                       "Exchange Online ATP"},
            {"EXCHANGESTANDARD",                     "Exchange Online Plan 1"},
            {"EXCHANGE_S_ENTERPRISE",                "Exchange Online Plan 2 S"},
            {"EXCHANGEENTERPRISE",                   "Exchange Online Plan 2"},
            {"RIGHTSMANAGEMENT_STANDARD_FACULTY",    "Information Rights Management for Faculty"},
            {"RIGHTSMANAGEMENT_STANDARD_STUDENT",    "Information Rights Management for Students"},
            {"INTUNE_A_VL",                          "Intune (Volume License)"},
            {"MCOLITE",                              "Lync Online (Plan 1)"},
            {"CRMSTORAGE",                           "Microsoft Dynamics CRM Online Additional Storage"},
            {"FLOW_FREE",                            "Microsoft Flow Free"},
            {"IT_ACADEMY_AD",                        "Microsoft Imagine Academy"},
            {"POWERAPPS_INDIVIDUAL_USER",            "Microsoft PowerApps and Logic flows"},
            {"STREAM",                               "Microsoft Stream"},
            {"MICROSOFT_BUSINESS_CENTER",            "MICROSOFT_BUSINESS_CENTER"},
            {"MEE_FACULTY",                          "Minecraft Education Edition Faculty"},
            {"MEE_STUDENT",                          "Minecraft Education Edition Student"},
            {"STANDARDWOFFPACK_STUDENT",             "O365 Education E1 for Students"},
            {"STANDARDWOFFPACK_IW_FACULTY",          "O365 Education for Faculty"},
            {"STANDARDWOFFPACK_IW_STUDENT",          "O365 Education for Students"},
            {"STANDARDPACK_STUDENT",                 "Office 365 (Plan A1) for Students"},
            {"ENTERPRISEPACKLRG",                    "Office 365 (Plan E3)"},
            {"EQUIVIO_ANALYTICS_FACULTY",            "Office 365 Advanced Compliance for faculty"},
            {"STANDARDWOFFPACK_FACULTY",             "Office 365 Education E1 for Faculty"},
            {"ENTERPRISEWITHSCAL_FACULTY",           "Office 365 Education E4 for Faculty"},
            {"ENTERPRISEWITHSCAL_STUDENT",           "Office 365 Education E4 for Students"},
            {"STANDARDPACK",                         "Office 365 Enterprise E1"},
            {"STANDARDWOFFPACK",                     "Office 365 Enterprise E2"},
            {"ENTERPRISEPACKWITHOUTPROPLUS",         "Office 365 Enterprise E3 without ProPlus Add-on"},
            {"ENTERPRISEPACK",                       "Office 365 Enterprise E3"},
            {"ENTERPRISEWITHSCAL",                   "Office 365 Enterprise E4"},
            {"ENTERPRISEPREMIUM",                    "Office 365 Enterprise E5"},
            {"DESKLESSPACK_YAMMER",                  "Office 365 Enterprise K1 with Yammer"},
            {"DESKLESSPACK",                         "Office 365 Enterprise K1 without Yammer"},
            {"DESKLESSWOFFPACK",                     "Office 365 Enterprise K2"},
            {"MIDSIZEPACK",                          "Office 365 Midsize Business"},
            {"STANDARDWOFFPACKPACK_FACULTY",         "Office 365 Plan A2 for Faculty"},
            {"STANDARDWOFFPACKPACK_STUDENT",         "Office 365 Plan A2 for Students"},
            {"ENTERPRISEPACK_FACULTY",               "Office 365 Plan A3 for Faculty"},
            {"ENTERPRISEPACK_STUDENT",               "Office 365 Plan A3 for Students"},
            {"OFFICESUBSCRIPTION_FACULTY",           "Office 365 ProPlus for Faculty"},
            {"LITEPACK_P2",                          "Office 365 Small Business Premium"},
            {"WACSHAREPOINTSTD",                     "Office Online STD"},
            {"SHAREPOINTWAC",                        "Office Online"},
            {"OFFICESUBSCRIPTION_STUDENT",           "Office ProPlus Student Benefit"},
            {"OFFICE_PRO_PLUS_SUBSCRIPTION_SMBIZ",   "Office ProPlus"},
            {"POWER_BI_INDIVIDUAL_USER",             "Power BI for Office 365 Individual"},
            {"POWER_BI_STANDALONE",                  "Power BI for Office 365 Standalone"},
            {"POWER_BI_STANDARD",                    "Power BI for Office 365 Standard"},
            {"POWER_BI_PRO",                         "Power BI Pro"},
            {"PROJECTESSENTIALS",                    "Project Lite"},
            {"PROJECTONLINE_PLAN_1_FACULTY",         "Project Online for Faculty Plan 1"},
            {"PROJECTONLINE_PLAN_2_FACULTY",         "Project Online for Faculty Plan 2"},
            {"PROJECTONLINE_PLAN_1_STUDENT",         "Project Online for Students Plan 1"},
            {"PROJECTONLINE_PLAN_2_STUDENT",         "Project Online for Students Plan 2"},
            {"PROJECTPREMIUM",                       "Project Online Premium"},
            {"PROJECTPROFESSIONAL",                  "Project Online Professional"},
            {"PROJECTONLINE_PLAN_1",                 "Project Online with Project for Office 365"},
            {"PROJECTCLIENT",                        "Project Pro for Office 365"},
            {"SHAREPOINTLITE",                       "SharePoint Online (Plan 1) Lite"},
            {"SHAREPOINTENTERPRISE_MIDMARKET",       "SharePoint Online (Plan 1) MidMarket"},
            {"SHAREPOINTENTERPRISE",                 "SharePoint Online (Plan 2)"},
            {"SHAREPOINTSTANDARD",                   "SharePoint Online Plan 1"},
            {"VISIOCLIENT",                          "Visio Pro for Office 365"},
            {"YAMMER_ENTERPRISE",                    "Yammer Enterprise"},
            {"YAMMER_MIDSIZE",                       "Yammer Midsize" },
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