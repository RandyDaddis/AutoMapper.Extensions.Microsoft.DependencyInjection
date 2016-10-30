using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class Currency_CrudServices : ICurrency_CrudServices
    {
        #region Private Fields

        private readonly ICurrency_Queries _queries;
        private readonly ICurrencyRepository _repository;
        private readonly ICurrencyMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        public Currency_CrudServices(ICurrency_Queries currency_Queries, 
                                    ICurrencyRepository repository,
                                    ICurrencyMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter
                                    )
        {
            _queries = currency_Queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(CurrencyCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Currency_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(CurrencyDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((CurrencyDto)dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                CurrencyCmd cmd = _queries.GetCmd(x => x.Id == dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> Currency_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Currency_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(CurrencyCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Currency_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Currency_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition || 
                    ((Dictionary<string,string>)customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Currency_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(CurrencyCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Currency_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Currency_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(CurrencyCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Currency_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Currency_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual CurrencyCmd Cmd_Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            CurrencyCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "CurrencyCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                Dna.NetCore.Core.BLL.Entities.Common.Currency dao = _repository.Create(out customMessage1);

                if ((Dna.NetCore.Core.BLL.Entities.Common.Currency)dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "CurrencyCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "CurrencyCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
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

        public virtual CurrencyCmd Cmd_SetDefaultPropertyValues(CurrencyCmd cmd, string userName)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            return cmd;
        }

        private CurrencyCmd SetAddProperties(CurrencyCmd cmd, string userName)
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

        private CurrencyCmd SetDeleteProperties(CurrencyCmd cmd, string userName)
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

        private CurrencyCmd SetUpdateProperties(CurrencyCmd cmd, string userName)
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
