using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Services.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Entities;
using Dna.NetCore.Core.BLL.Constants;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class Country_CrudServices : ICountry_CrudServices
    {
        #region Private Fields

        private readonly ICurrency_Queries _currencyQueries;
        private readonly ILocale_Queries _localeQueries;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        private readonly ICountry_Queries _queries;
        private readonly ICountryRepository _repository;
        private readonly ICountryMapper _mapper;

        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        public Country_CrudServices(ICurrency_Queries currencyQueries,
                                    ILocale_Queries localeQueries,
                                    ISystemSetting_Queries systemSettingQueries,
                                    ICountry_Queries country_Queries, 
                                    ICountryRepository repository,
                                    ICountryMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter
                                    )
        {
            _currencyQueries = currencyQueries;
            _localeQueries = localeQueries;
            _systemSettingQueries = systemSettingQueries;
            _queries = country_Queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(CountryCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Country_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(CountryDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                CountryCmd cmd = _queries.GetCmd(dto.Abbreviation);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> Country_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Country_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(CountryCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Country_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Country_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Country_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(CountryCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Country_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Country_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(CountryCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Country_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Country_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual CountryCmd Cmd_Create(string userName, out CustomMessage customMessage, string phoneNumberCountryCode = "", string currencyCode = "", int lcidDecimal = 0)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            CountryCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "CountryCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                Country dao = _repository.Create(out customMessage1);

                if ((Country)dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "CountryCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "CountryCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
                    }
                    else
                    {
                        cmd = Cmd_SetDefaultPropertyValues(cmd, userName, phoneNumberCountryCode, currencyCode, lcidDecimal);
                    }
                }
            }

            customMessage = customMessage1;

            return cmd;
        }

        public virtual CountryCmd Cmd_SetDefaultPropertyValues(CountryCmd cmd, string userName, string phoneNumberCountryCode = "", string currencyCode = "", int lcidDecimal = 0)
        {
            if (cmd == null)
                return null;
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("Country_CrudServices.Cmd_SetDefaultProperties() - userName");

            cmd.PhoneNumberCountryCode = phoneNumberCountryCode;
            cmd.IsShippingAllowed = true;
            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            cmd = Cmd_SetCurrencyPropertyValues(cmd, currencyCode);
            cmd = Cmd_SetLocalePropertyValues(cmd, lcidDecimal);

            return cmd;
        }

        private CountryCmd Cmd_SetCurrencyPropertyValues(CountryCmd cmd, string currencyCode = "")
        {
            if (cmd == null)
                return null;

            CurrencyDto currency = null;

            if (string.IsNullOrEmpty(currencyCode))
                currencyCode = GetSystemSettingStringValue(SystemSettingConstants.Core_CurrencyCode);

            if (!string.IsNullOrEmpty(currencyCode))
                currency = _currencyQueries.Get(x => x.Code == currencyCode);

            if (currency != null)
                cmd.CurrencyId = currency.Id;

            return cmd;
        }

        private CountryCmd Cmd_SetLocalePropertyValues(CountryCmd cmd, int lcidDecimal = 0)
        {
            if (cmd == null)
                return null;

            LocaleDto locale = null;

            if (lcidDecimal < 1)
                lcidDecimal = GetSystemSettingIntegerValue(SystemSettingConstants.Core_LocaleLcidDecimal);

            if (lcidDecimal > 0)
                locale = _localeQueries.Get(x => x.LCIDDecimal == lcidDecimal);

            if (locale != null)
                cmd.LocaleId = locale.Id;

            return cmd;
        }

        private int GetSystemSettingIntegerValue(string systemName)
        {
            int value = 0;

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.IntegerValue;
            }

            return value;
        }

        private string GetSystemSettingStringValue(string systemName)
        {
            string value = "";

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.StringValue;
            }

            return value;
        }

        private CountryCmd SetAddProperties(CountryCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.AddedBy = userName;
                cmd.AddedDate = _dateTimeAdapter.UtcNow;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;

                foreach (StateOrProvinceCmd stateOrProvince in cmd.StateOrProvinces)
                {
                    stateOrProvince.AddedBy = cmd.AddedBy;
                    stateOrProvince.AddedDate = cmd.AddedDate;
                    stateOrProvince.ChangedBy = userName;
                    stateOrProvince.ChangedDate = _dateTimeAdapter.UtcNow;
                }
            }
            return cmd;
        }

        private CountryCmd SetDeleteProperties(CountryCmd cmd, string userName)
        {
            if (cmd != null)
            {
                // POLICY: branch logic to set entity.IsDeleted or to execute IDbSet<>.Remove(TEntity entity);
                cmd.IsDeleted = true;
                cmd.IsActive = false;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;

                // TODO: review child entity cascade 
                foreach (StateOrProvinceCmd stateOrProvince in cmd.StateOrProvinces)
                {
                    stateOrProvince.IsDeleted = cmd.IsDeleted;
                    stateOrProvince.IsActive = cmd.IsActive;
                    stateOrProvince.ChangedBy = userName;
                    stateOrProvince.ChangedDate = _dateTimeAdapter.UtcNow;
                }
            }
            return cmd;
        }

        private CountryCmd SetUpdateProperties(CountryCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }
            return cmd;
        }

        #endregion
    }
}
