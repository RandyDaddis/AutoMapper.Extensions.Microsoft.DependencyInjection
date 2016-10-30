using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Mappers.Localization;
using Dna.NetCore.Core.BLL.Repositories.Localization;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Dna.NetCore.Core.BLL.Services.Localization
{
    public partial class Locale_CrudServices : ILocale_CrudServices
    {
        #region Private Fields

        private readonly ILocale_Queries _queries;
        private readonly ILocaleRepository _repository;
        private readonly ILocaleMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

		#endregion

		#region ctor

        public Locale_CrudServices(ILocale_Queries locale_Queries, 
                                    ILocaleRepository repository,
                                    ILocaleMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter
                                    )
		{
            _queries = locale_Queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

		#endregion

        #region CRUD Methods

        public virtual void Add(LocaleCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Locale_CrudServices.Add(cmd, userName) | Update(cmd, userName) - null returned";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(LocaleDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((LocaleDto)dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                LocaleCmd cmd = _queries.GetCmd(x => x.Id == dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> Locale_CrudServices.Delete(cmd, userName) | _claim_Queries.GetCmd(dto.Id) - null returned";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Locale_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - returned null CustomMessage";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(LocaleCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Locale_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Locale_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - null returned";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Locale_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - null returned";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(LocaleCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Locale_CrudServices.Cmd_Validate(cmd) = ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Locale_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(LocaleCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Locale_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Locale_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - null returned";
                }
            }

            return customMessage;
        }

        public virtual LocaleCmd Cmd_Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            LocaleCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "LocaleCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                Locale dao = _repository.Create(out customMessage1);

                if ((Locale)dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "LocaleCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "LocaleCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
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

        public virtual LocaleCmd Cmd_SetDefaultPropertyValues(LocaleCmd cmd, string userName)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            return cmd;
        }

        private LocaleCmd SetAddProperties(LocaleCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.AddedBy = userName;
                cmd.AddedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        private LocaleCmd SetDeleteProperties(LocaleCmd cmd)
        {
            if (cmd != null)
            {
                // POLICY: branch logic to set entity.IsDeleted or to execute IDbSet<>.Remove(TEntity entity);
                cmd.IsDeleted = true;
                cmd.IsActive = false;
            }

            return cmd;
        }

        private LocaleCmd SetUpdateProperties(LocaleCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.ChangedBy = userName;

                if (cmd.Id == 0)
                    cmd.ChangedDate = cmd.AddedDate;
                else
                    cmd.ChangedDate = _dateTimeAdapter.UtcNow;
            }

            return cmd;
        }

        #endregion
    }
}
