using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class StateOrProvince_CrudServices : IStateOrProvince_CrudServices
    {
        #region Private Fields

        private readonly ICountry_Queries _countryQueries;
        //private readonly ITimeZone_Queries _timeZoneQueries;
        //private readonly ITimeZoneInfoHelperServices _timeZoneInfoHelperService;

        private readonly IStateOrProvince_Queries _queries;
        private readonly IStateOrProvinceRepository _repository;
        private readonly IStateOrProvinceMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        public StateOrProvince_CrudServices(ICountry_Queries country_Queries,
                                                //ITimeZone_Queries timeZoneQueries,
                                                //ITimeZoneInfoHelperServices timeZoneInfoHelperService,
                                                IStateOrProvince_Queries stateOrProvince_Queries, 
                                                IStateOrProvinceRepository repository,
                                                IStateOrProvinceMapper mapper,
                                                ICommandBus commandBus,
                                                IDateTimeAdapter dateTimeAdapter
                                                )
        {
            _countryQueries = country_Queries;
            //_timeZoneQueries = timeZoneQueries;
            //_timeZoneInfoHelperService = timeZoneInfoHelperService;
            _queries = stateOrProvince_Queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(StateOrProvinceCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> StateOrProvince_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(StateOrProvinceDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                StateOrProvinceCmd cmd = _queries.GetCmd(dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> StateOrProvince_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> StateOrProvince_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(StateOrProvinceCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> StateOrProvince_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> StateOrProvince_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> StateOrProvince_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(StateOrProvinceCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> StateOrProvince_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> StateOrProvince_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(StateOrProvinceCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> StateOrProvince_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> StateOrProvince_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual StateOrProvinceCmd Cmd_Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            StateOrProvinceCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "StateOrProvinceCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                StateOrProvince dao = _repository.Create(out customMessage1);

                if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "StateOrProvinceCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "StateOrProvinceCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
                    }
                    else
                    {
                        cmd = Cmd_SetDefaultPropertyValues(cmd, userName);
                    }
                }
            }

            customMessage = customMessage1;

            return cmd;
        }

        private StateOrProvinceCmd Cmd_SetDefaultPropertyValues(StateOrProvinceCmd cmd, string userName)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsShippingAllowed = true;
            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            return cmd;
        }

        private StateOrProvinceCmd Cmd_SetCountryPropertyValues(StateOrProvinceCmd cmd, string countryAbbreviation)
        {
            if (cmd == null)
                return null;

            CountryDto country = null;

            if (string.IsNullOrEmpty(countryAbbreviation))
                country = _countryQueries.GetDefault();
            else
                country = _countryQueries.Get(a => a.Abbreviation == countryAbbreviation);

            if (country != null)
                cmd.CountryId = country.Id;

            return cmd;
        }

        //private StateOrProvinceCmd Cmd_SetTimeZonePropertyValues(StateOrProvinceCmd cmd, ICollection<TimeZoneCmd> timeZones = null)
        //{
        //    if (cmd == null)
        //        return null;

        //    foreach (var item in timeZones)
        //        cmd.TimeZones.Add(item);

        //    return cmd;
        //}

        public virtual StateOrProvinceCmd Cmd_SetPropertyValues(StateOrProvinceCmd cmd,
                                                            string abbreviation, string displayName,
                                                            decimal salesTaxRate = 0,
                                                            int countryId = 0, string countryAbbeviation = "",
                                                            ICollection<TimeZoneCmd> timeZones = null,
                                                            List<CountyCmd> counties = null,
                                                            List<CityCmd> cities = null,
                                                            bool isShippingAllowed = true,
                                                            bool isActive = true)
        {
            if (cmd == null)
                return null;

            cmd.Abbreviation = abbreviation;
            cmd.DisplayName = displayName;
            cmd.SalesTaxRate = salesTaxRate;

            cmd.CountryId = countryId;
            if (!string.IsNullOrEmpty(countryAbbeviation))
                cmd = Cmd_SetCountryPropertyValues(cmd, countryAbbeviation);

            if (timeZones != null)
                foreach (TimeZoneCmd item in timeZones)
                    cmd.TimeZones.Add(item);

            if (counties != null)
                foreach (CountyCmd item in counties)
                    cmd.Counties.Add(item);

            if (cities != null)
                foreach (CityCmd item in cities)
                    cmd.Cities.Add(item);

            // default values
            cmd.IsShippingAllowed = isShippingAllowed;
            cmd.IsActive = isActive;

            return cmd;
        }

        private StateOrProvinceCmd SetAddProperties(StateOrProvinceCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.AddedBy = userName;
                cmd.AddedDate = _dateTimeAdapter.UtcNow;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        private StateOrProvinceCmd SetDeleteProperties(StateOrProvinceCmd cmd, string userName)
        {
            if (cmd != null)
            {
                // POLICY: branch logic to set entity.IsDeleted or to execute IDbSet<>.Remove(TEntity entity);
                cmd.IsDeleted = true;
                cmd.IsActive = false;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        private StateOrProvinceCmd SetUpdateProperties(StateOrProvinceCmd cmd, string userName)
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
