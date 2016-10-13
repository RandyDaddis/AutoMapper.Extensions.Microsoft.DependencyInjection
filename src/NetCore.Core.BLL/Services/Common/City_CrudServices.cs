using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;
using System.Linq;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class City_CrudServices : ICity_CrudServices
    {
        #region Private Fields

        private readonly IStateOrProvince_Queries _stateOrProvinceQueries;

        private readonly ICity_Queries _queries;
        private readonly ICityRepository _repository;
        private readonly ICityMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        //public delegate City_CrudServices Factory();

        //public City_CrudServices()
        //{
        //    _stateOrProvinceQueries = Ioc.Resolve<IStateOrProvince_Queries>();
        //    if (_stateOrProvinceQueries == null) throw new Exception("StateOrProvince_CrudServices() - unable to resolve Ioc.Resolve<IStateOrProvince_Queries>()");

        //    _queries = Ioc.Resolve<ICity_Queries>();
        //    if (_queries == null) throw new Exception("City_CrudServices() - unable to resolve Ioc.Resolve<ICity_Queries>()");

        //    _repository = Ioc.Resolve<ICityRepository>();
        //    if (_repository == null)
        //        throw new Exception("City_CrudServices() - unable to resolve Ioc.Resolve<ICityRepository>()");

        //    _mapper = Ioc.Resolve<ICityMapper>();
        //    if (_mapper == null)
        //        throw new Exception("City_CrudServices() - unable to resolve Ioc.Resolve<ICityMapper>()");

        //    _commandBus = Ioc.Resolve<ICommandBus>();
        //    if (_commandBus == null)
        //        throw new Exception("City_CrudServices() - unable to resolve Ioc.Resolve<ICommandBus>()");

        //    _dateTimeAdapter = Ioc.Resolve<IDateTimeAdapter>();
        //    if (_dateTimeAdapter == null) throw new Exception("City_CrudServices() - unable to resolve Ioc.Resolve<IDateTimeAdapter>()");
        //}

        public City_CrudServices(IStateOrProvince_Queries stateOrProvince_Queries, 
                                    ICity_Queries queries, 
                                    ICityRepository repository,
                                    ICityMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter
                                    )
        {
            _stateOrProvinceQueries = stateOrProvince_Queries;
            _queries = queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(CityCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> City_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(CityDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                CityCmd cmd = _queries.GetCmd(dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> City_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> City_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(CityCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> City_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> City_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> City_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(CityCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> City_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> City_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(CityCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> City_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> City_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual CityCmd Cmd_Create(string userName, string stateOrProvinceAbbreviation, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            CityCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "CityCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else if (string.IsNullOrEmpty(stateOrProvinceAbbreviation))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "CityCrudServices.Cmd_reae() - ArgumentNullException('stateOrProvinceAbbreviation')";
            }
            else
            {
                City dao = _repository.Create(out customMessage1);

                if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "CityCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "CityCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
                    }
                    else
                    {
                        cmd = Cmd_SetDefaultPropertyValues(cmd, userName, stateOrProvinceAbbreviation);
                    }
                }
            }

            customMessage = customMessage1;

            return cmd;
        }

        public virtual CityCmd Cmd_SetDefaultPropertyValues(CityCmd cmd, string userName, string stateOrProvinceAbbreviation)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            cmd = Cmd_SetStateOrProvincePropertyValues(cmd, stateOrProvinceAbbreviation);

            return cmd;
        }

        private CityCmd Cmd_SetStateOrProvincePropertyValues(CityCmd cmd, string stateOrProvinceAbbreviation)
        {
            if (cmd == null)
                return null;

            StateOrProvinceDto stateOrProvince = null;

            if (!string.IsNullOrEmpty(stateOrProvinceAbbreviation))
                stateOrProvince = _stateOrProvinceQueries.Get(a => a.Abbreviation == stateOrProvinceAbbreviation);
            else
                stateOrProvince = _stateOrProvinceQueries.GetDefault();

            if (stateOrProvince != null)
            {
                cmd.StateOrProvinceId = stateOrProvince.Id;
                cmd.StateOrProvinceAbbreviation = stateOrProvince.Abbreviation;
            }

            return cmd;
        }

        private CityCmd SetAddProperties(CityCmd cmd, string userName)
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

        private CityCmd SetDeleteProperties(CityCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.IsDeleted = true;
                cmd.IsActive = false;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        private CityCmd SetUpdateProperties(CityCmd cmd, string userName)
        {
            if (cmd != null)
            {
                // TODO: consider refactoring to this.GetUserName() after refactoring AuthenticationService to be self-hosted instead of running in the IIS pipeline
                // DEVNOTE: OWIN middleware is currently executing in the IIS pipeline which has a dependency on HTTP
                // cmd.ChangedBy = GetUserName();
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        #endregion
    }
}
