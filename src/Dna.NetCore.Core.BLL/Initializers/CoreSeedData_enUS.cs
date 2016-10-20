using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.Constants;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Initializers.Common;
using Dna.NetCore.Core.BLL.Initializers.Localization;
using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.BLL.Services.Plugins;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Initializers
{
    public class CoreSeedData_enUS : ISeedData
    {
        #region Private Fields

        private readonly CommonSeedData_enUS _commonSeedData;
        private readonly LocaleSeedData_enUS _localeSeedData;
        private readonly ISystemSetting_CrudServices _systemSettingCrudServices;
        private readonly IPlugin_CrudServices _pluginCrudServices;
        private readonly IPlugin_Queries _pluginQueries;
        private string _pluginSystemName = "Dna.NetCore.Core.BLL";
        private int _pluginId;
        private CustomMessage _customMessage;
        private string _userName;

        #endregion

        #region ctor

        public CoreSeedData_enUS(CommonSeedData_enUS commonSeedData,
                                 LocaleSeedData_enUS localeSeedData,
                                 ISystemSetting_CrudServices systemSettingCrudServices,
                                 IPlugin_CrudServices pluginCrudServices,
                                 IPlugin_Queries pluginQueries)
        {
            _commonSeedData = commonSeedData;
            _localeSeedData = localeSeedData;
            _pluginCrudServices = pluginCrudServices;
            _pluginQueries = pluginQueries;
            _systemSettingCrudServices = systemSettingCrudServices;
        }

        #endregion ctor

        #region Methods

        public CustomMessage Execute(string userName)
        {
            _userName = userName;
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            // init order:
            //
            // 1. Locale - LocaleSeedData_enUS
            // 2. Currencies - CommonSeedData_enUS | CurrencySeedData_enUS
            // 3. Countries - CommonSeedData_enUS

            //PluginSeedData();
            GeneratePlugin();
            GenerateSystemSettings();

            LocaleSeedData();
            CommonSeedData();
            //LookupSeedData();
            //SecuritySeedData();

            return _customMessage;
        }

        //private void PluginSeedData()
        //{
        //    PluginSeedData_enUS plugins = new PluginSeedData_enUS();  //_autofacContainer);

        //    CustomMessage seedMessages = plugins.Seed(_userName);

        //    BubbleUpCustomMessageDictionaries(seedMessages);
        //}

        private void LocaleSeedData()
        {
            CustomMessage seedMessages = _localeSeedData.Execute(_userName);

            BubbleUpCustomMessageDictionaries(seedMessages);
        }

        private void CommonSeedData()
        {
            CustomMessage seedMessages = _commonSeedData.Execute(_userName);

            BubbleUpCustomMessageDictionaries(seedMessages);
        }

        //private void SecuritySeedData()
        //{
        //    SecuritySeedData_enUS security = new SecuritySeedData_enUS();

        //    CustomMessage seedMessages = security.Seed(_userName);

        //    BubbleUpCustomMessageDictionaries(seedMessages);
        //}

        private void GeneratePlugin()
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            int addSuccessCount = 0;
            int addFailureCount = 0;

            PluginCmd cmd = _pluginCrudServices.Cmd_Create(_userName, out customMessage);

            if (cmd == null)
            {
                addFailureCount++;
            }
            else
            {
                cmd.SystemName = _pluginSystemName;
                cmd.DisplayName = "Core";
                cmd.Notes = "The purpose of the Core is to group functionality that can be utilized by all modules";

                _pluginCrudServices.Add(cmd, _userName, out customMessage);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(), IsErrorCondition = true, Message = "InventorySeedData_enUS.GeneratePlugin() | _pluginCrudServices.Add() - null returned" };
                    addFailureCount++;
                }
                else
                {
                    if (customMessage.MessageDictionary1 != null && customMessage.MessageDictionary1.ContainsKey("AddId"))
                    {
                        _pluginId = int.Parse(customMessage.MessageDictionary1["AddId"]);
                        addSuccessCount++;
                    }
                    else
                    {
                        addFailureCount++;
                    }
                }
            }

            AddResultCountsToCustomMessage("Plugins", addSuccessCount, addFailureCount);
        }

        private void GenerateSystemSettings()
        {
            int addSuccessCount = 0;
            int addFailureCount = 0;

            List<SystemSetting> list = GenerateSytemSettingList();

            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _systemSettingCrudServices.Add(list, out customMessage1);

            if (customMessage1 == null)
            {
                customMessage1 = new CustomMessage()
                {
                    MessageDictionary1 = new Dictionary<string, string>(),
                    MessageDictionary2 = new Dictionary<string, string>(),
                    IsErrorCondition = true,
                    Message = "-->> CoreSeedData_enUS.GenerateSystemSettinges() - SystemSetting_CrudServices.Add(List<SystemSetting> list, out CustomMessage customMessage) - Add(entity, out customMessage1); - null customMessage1 returned"
                };
            }
            else
            {
                if (customMessage1.MessageDictionary1 != null && customMessage1.MessageDictionary1.Count > 0)
                    if (customMessage1.MessageDictionary1.ContainsKey("SystemSetting_Success"))
                        addSuccessCount = int.Parse(customMessage1.MessageDictionary1["SystemSetting_Success"]);

                if (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count > 0)
                    if (customMessage1.MessageDictionary2.ContainsKey("SystemSetting_Failure"))
                        addFailureCount = int.Parse(customMessage1.MessageDictionary2["SystemSetting_Failure"]);
            }

            AddResultCountsToCustomMessage("SystemSetting", addSuccessCount, addFailureCount);
        }

        private List<SystemSetting> GenerateSytemSettingList()
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            List<SystemSetting> list = new List<SystemSetting>();

            SystemSetting dao1 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao2 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao3 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao4 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao5 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao6 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao7 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao8 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao9 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao10 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao11 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao12 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao13 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao14 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao15 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao16 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao17 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao18 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao19 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao20 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao21 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao22 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao23 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao24 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao25 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao26 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao27 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao28 = _systemSettingCrudServices.Create(_userName, out customMessage1);
            SystemSetting dao29 = _systemSettingCrudServices.Create(_userName, out customMessage1);

            dao1 = _systemSettingCrudServices.SetPropertyValues(dao1, _pluginId, SystemSettingConstants.Core_AddressTypeSystemName, "Address Type", "", "Home");
            dao2 = _systemSettingCrudServices.SetPropertyValues(dao2, _pluginId, SystemSettingConstants.Core_BasePathForDataFiles, "Base Path for Data Files", "", "App_Data");
            dao3 = _systemSettingCrudServices.SetPropertyValues(dao3, _pluginId, SystemSettingConstants.Core_ClaimTypes_Tenant, "Tenant ClaimType", "", "http://daddis.net/dna/claims/tenant");
            dao4 = _systemSettingCrudServices.SetPropertyValues(dao4, _pluginId, SystemSettingConstants.Core_CityDisplayName, "Default City DisplayName", "", "Franklin Borough");
            dao5 = _systemSettingCrudServices.SetPropertyValues(dao5, _pluginId, SystemSettingConstants.Core_CountyDisplayName, "Default County DisplayName", "", "Sussex");
            dao6 = _systemSettingCrudServices.SetPropertyValues(dao6, _pluginId, SystemSettingConstants.Core_CountryAbbreviation, "Default Country Abbreviation", "", "US");
            dao7 = _systemSettingCrudServices.SetPropertyValues(dao7, _pluginId, SystemSettingConstants.Core_CurrencyCode, "Default Currency Code", "", "USD");
            dao8 = _systemSettingCrudServices.SetPropertyValues(dao8, _pluginId, SystemSettingConstants.Core_IsActive, "is Active (used by SetDefaultPropertyValues() for various types)", "", "", true);
            dao9 = _systemSettingCrudServices.SetPropertyValues(dao9, _pluginId, SystemSettingConstants.Core_IsDeleteEntityPermanent, "is Delete Entity Permanent", "", "", false);
            dao10 = _systemSettingCrudServices.SetPropertyValues(dao10, _pluginId, SystemSettingConstants.Core_LocaleLcidDecimal, "Locale LcidDecimal", "", "", false, 0M, 1033);
            dao11 = _systemSettingCrudServices.SetPropertyValues(dao11, _pluginId, SystemSettingConstants.Core_MaximumUIErrorMessageLength, "Maximum Error Message Length", "", "US", false, 0M, 512);
            dao12 = _systemSettingCrudServices.SetPropertyValues(dao12, _pluginId, SystemSettingConstants.Core_MimeTypeSystemName, "MimeType", "", ".jpg");
            dao13 = _systemSettingCrudServices.SetPropertyValues(dao13, _pluginId, SystemSettingConstants.Core_MimeTypeGroup_ApplicationSystemName, "Application MimeType Group", "", "Applicaton");
            dao14 = _systemSettingCrudServices.SetPropertyValues(dao14, _pluginId, SystemSettingConstants.Core_MimeTypeGroup_ImageSystemName, "Image MimeType Group", "", "Image");
            dao15 = _systemSettingCrudServices.SetPropertyValues(dao15, _pluginId, SystemSettingConstants.Core_MimeTypeGroup_TextSystemName, "Text MimeType Group", "", "Text");
            dao16 = _systemSettingCrudServices.SetPropertyValues(dao16, _pluginId, SystemSettingConstants.Core_PhoneNumber_CountryCode, "Default Phone Number Country Code", "", "1");
            dao17 = _systemSettingCrudServices.SetPropertyValues(dao17, _pluginId, SystemSettingConstants.Core_PhoneNumberTypeSystemName, "Default Phone Number Type", "", "CellPhone");
            dao18 = _systemSettingCrudServices.SetPropertyValues(dao18, _pluginId, SystemSettingConstants.Core_SslIsEnabled, "SSL Is Enabled", "", "", false);
            dao19 = _systemSettingCrudServices.SetPropertyValues(dao19, _pluginId, SystemSettingConstants.Core_SSLUrl, "SSL URL", "", "");
            dao20 = _systemSettingCrudServices.SetPropertyValues(dao20, _pluginId, SystemSettingConstants.Core_SystemSettingIsActive, "System Setting Is Active", "", "", true);
            dao21 = _systemSettingCrudServices.SetPropertyValues(dao21, _pluginId, SystemSettingConstants.Core_TimeZoneInfoId, "Default TimeZoneInfoId", "", "Eastern Standard Time");
            dao22 = _systemSettingCrudServices.SetPropertyValues(dao22, _pluginId, SystemSettingConstants.Core_Us_ShippingIsAllowed, "USA - Is Shipping Allowed", "", "", true);
            dao23 = _systemSettingCrudServices.SetPropertyValues(dao23, _pluginId, SystemSettingConstants.Core_US_Taxes_NJ_SalesTaxRate, "Default NJ Sales Tax Rate", "", "", false, 0.06M);
            dao24 = _systemSettingCrudServices.SetPropertyValues(dao24, _pluginId, SystemSettingConstants.Core_US_Taxes_NY_SalesTaxRate, "Default NY Sales Tax Rate", "", "", false, 0.0825M);
            dao25 = _systemSettingCrudServices.SetPropertyValues(dao25, _pluginId, SystemSettingConstants.Core_US_Taxes_PA_SalesTaxRate, "Default PA Sales Tax Rate", "", "", false, 0.06M);
            dao26 = _systemSettingCrudServices.SetPropertyValues(dao26, _pluginId, SystemSettingConstants.Core_US_DefaultState, "USA - Default State Abbreviation", "", "NJ");
            dao27 = _systemSettingCrudServices.SetPropertyValues(dao27, _pluginId, SystemSettingConstants.Core_US_Taxes_SalesTaxState, "USA - Default Sales Tax State", "", "NJ", false);
            dao28 = _systemSettingCrudServices.SetPropertyValues(dao28, _pluginId, SystemSettingConstants.Core_US_Taxes_VatIsEnabled, "USA - VAT Is Enabled", "", "", false);
            dao29 = _systemSettingCrudServices.SetPropertyValues(dao29, _pluginId, SystemSettingConstants.Core_UserName, "Default User Name", "", _userName);

            list.Add(dao1);
            list.Add(dao2);
            list.Add(dao3);
            list.Add(dao4);
            list.Add(dao5);
            list.Add(dao6);
            list.Add(dao7);
            list.Add(dao8);
            list.Add(dao9);
            list.Add(dao10);
            list.Add(dao11);
            list.Add(dao12);
            list.Add(dao13);
            list.Add(dao14);
            list.Add(dao15);
            list.Add(dao16);
            list.Add(dao17);
            list.Add(dao18);
            list.Add(dao19);
            list.Add(dao20);
            list.Add(dao21);
            list.Add(dao22);
            list.Add(dao23);
            list.Add(dao24);
            list.Add(dao25);
            list.Add(dao26);
            list.Add(dao27);
            list.Add(dao28);

            return list;
        }

        private void AddResultCountsToCustomMessage(string entityName, int addSuccessCount, int addFailureCount)
        {
            if (_customMessage == null)
                _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            if (_customMessage.MessageDictionary1 == null)
                _customMessage.MessageDictionary1 = new Dictionary<string, string>();
            if (_customMessage.MessageDictionary2 == null)
                _customMessage.MessageDictionary2 = new Dictionary<string, string>();

            _customMessage.MessageDictionary1.Add("Core." + entityName + ".AddSuccessCount", addSuccessCount.ToString());
            _customMessage.MessageDictionary2.Add("Core." + entityName + ".AddFailureCount", addFailureCount.ToString());
        }

        private void BubbleUpCustomMessageDictionaries(CustomMessage seedMessages)
        {
            if (seedMessages != null)
            {
                if (seedMessages.MessageDictionary1 != null)
                {
                    foreach (var message in seedMessages.MessageDictionary1)
                    {
                        if (_customMessage.MessageDictionary1.ContainsKey(message.Key))
                        {
                            int total = int.Parse(_customMessage.MessageDictionary1[message.Key]);
                            total += int.Parse(message.Value);
                            _customMessage.MessageDictionary1[message.Key] += total;
                        }
                        else
                        {
                            _customMessage.MessageDictionary1.Add(message.Key, message.Value);
                        }
                    }
                }
                if (seedMessages.MessageDictionary2 != null)
                {
                    foreach (var message in seedMessages.MessageDictionary2)
                    {
                        if (_customMessage.MessageDictionary2.ContainsKey(message.Key))
                        {
                            int total = int.Parse(_customMessage.MessageDictionary2[message.Key]);
                            total += int.Parse(message.Value);
                            _customMessage.MessageDictionary2[message.Key] = total.ToString();
                        }
                        else
                        {
                            _customMessage.MessageDictionary2.Add(message.Key, message.Value);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
