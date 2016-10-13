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
    public partial class AddressType_CrudServices : IAddressType_CrudServices
    {
        #region Private Fields

        private readonly IAddressType_Queries _queries;
        private readonly IAddressTypeRepository _repository;
        private readonly IAddressTypeMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        //public delegate AddressType_CrudServices Factory();

        //public AddressType_CrudServices()
        //{
        //    _queries = Ioc.Resolve<IAddressType_Queries>();
        //    if (_queries == null) throw new Exception("AddressType_CrudServices() - unable to resolve Ioc.Resolve<IAddressType_Queries>()");

        //    _repository = Ioc.Resolve<IAddressTypeRepository>();
        //    if (_repository == null)
        //        throw new Exception("AddressType_CrudServices() - unable to resolve Ioc.Resolve<IAddressTypeRepository>()");

        //    _mapper = Ioc.Resolve<IAddressTypeMapper>();
        //    if (_mapper == null)
        //        throw new Exception("AddressType_CrudServices() - unable to resolve Ioc.Resolve<IAddressTypeMapper>()");

        //    _commandBus = Ioc.Resolve<ICommandBus>();
        //    if (_commandBus == null)
        //        throw new Exception("AddressType_CrudServices() - unable to resolve Ioc.Resolve<ICommandBus>()");

        //    _dateTimeAdapter = Ioc.Resolve<IDateTimeAdapter>();
        //    if (_dateTimeAdapter == null) throw new Exception("AddressType_CrudServices() - unable to resolve Ioc.Resolve<IDateTimeAdapter>()");
        //}

        public AddressType_CrudServices(IAddressType_Queries queries, 
                                    IAddressTypeRepository repository,
                                    IAddressTypeMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter
                                    )
        {
            _queries = queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(AddressTypeCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> AddressType_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(AddressTypeDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                AddressTypeCmd cmd = _queries.GetCmd(dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> AddressType_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> AddressType_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(AddressTypeCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> AddressType_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> AddressType_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> AddressType_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(AddressTypeCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> AddressType_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> AddressType_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(AddressTypeCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> AddressType_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> AddressType_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual AddressTypeCmd Cmd_Create(string userName, string stateOrProvinceAbbreviation, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            AddressTypeCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "AddressTypeCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else if (string.IsNullOrEmpty(stateOrProvinceAbbreviation))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "AddressTypeCrudServices.Cmd_reae() - ArgumentNullException('stateOrProvinceAbbreviation')";
            }
            else
            {
                AddressType dao = _repository.Create(out customMessage1);

                if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "AddressTypeCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "AddressTypeCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
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

        public virtual AddressTypeCmd Cmd_SetDefaultPropertyValues(AddressTypeCmd cmd, string userName, string stateOrProvinceAbbreviation)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            return cmd;
        }

        private AddressTypeCmd SetAddProperties(AddressTypeCmd cmd, string userName)
        {
            if (cmd != null)
            {
                // DEVNOTE:  AuthenticationService is an OWIN middleware and is currently executing in the IIS pipeline which has a dependency on HTTP
                cmd.AddedBy = userName;  // TODO: consider refactoring to this.GetUserName() after refactoring AuthenticationService to be self-hosted instead of running in the IIS pipeline
                cmd.AddedDate = _dateTimeAdapter.UtcNow;
                cmd.ChangedBy = userName;
                cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        private AddressTypeCmd SetDeleteProperties(AddressTypeCmd cmd, string userName)
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

        private AddressTypeCmd SetUpdateProperties(AddressTypeCmd cmd, string userName)
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
