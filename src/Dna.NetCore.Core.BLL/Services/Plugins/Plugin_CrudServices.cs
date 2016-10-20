using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.Mappers.Plugins;
using Dna.NetCore.Core.BLL.Repositories.Plugins;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Dna.NetCore.Core.BLL.Services.Plugins
{
    public partial class Plugin_CrudServices : IPlugin_CrudServices
    {
        #region Private Fields

        private readonly IPlugin_Queries _queries;
        private readonly IPluginRepository _repository;
        private readonly IPluginMapper _mapper;
        private readonly ICommandBus _commandBus;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        public Plugin_CrudServices(IPlugin_Queries plugin_Queries,
                                    IPluginRepository repository,
                                    IPluginMapper mapper,
                                    ICommandBus commandBus,
                                    IDateTimeAdapter dateTimeAdapter)
        {
            _queries = plugin_Queries;
            _repository = repository;
            _mapper = mapper;
            _commandBus = commandBus;
            _dateTimeAdapter = dateTimeAdapter;
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(PluginCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Add(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Add(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetAddProperties(cmd, userName);

                Update(cmd, userName, out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Plugin_CrudServices.Add(cmd, userName) | Update(cmd, userName) - NullReferenceException: customMessage1";
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Delete(PluginDto dto, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dto == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Delete() - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Delete(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                PluginCmd cmd = _queries.GetCmd(dto.Id);

                if (cmd == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message += " -->> Plugin_CrudServices.Delete(cmd, userName) | _securityToken_Queries.GetCmd(dto.Id) - NullReferenceException: PluginCmd";
                }
                else
                {
                    cmd = SetDeleteProperties(cmd, userName);

                    Update(cmd, userName, out customMessage1);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Plugin_CrudServices.Delete(cmd, userName) | Update(cmd, userName) - NullReferenceException: customMessage1";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        public virtual void Update(PluginCmd cmd, string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Update(cmd) - ArgumentNullException";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> Plugin_CrudServices.Update(cmd, userName) - IsNullOrEmpty(userName)";
            }
            else
            {
                cmd = SetUpdateProperties(cmd, userName);

                customMessage1 = Cmd_Validate(cmd);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> Plugin_CrudServices.Update(cmd, userName) | Cmd_Validate(cmd) - NullReferenceException: customMessage1";
                }
                else if (!customMessage1.IsErrorCondition ||
                    (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count() == 0))
                {
                    customMessage1 = Cmd_Submit(cmd);

                    if (customMessage1 == null)
                    {
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = " -->> Plugin_CrudServices.Update(cmd, userName) | Cmd_Submit(cmd) - NullReferenceException: customMessage1";
                    }
                }
            }

            customMessage = customMessage1;

            return;
        }

        #endregion

        #region Helper Methods

        private CustomMessage Cmd_Validate(PluginCmd cmd)
        {
            CustomMessage customMessage = null;

            if (cmd == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Plugin_CrudServices.Cmd_Validate(cmd) = NullReferenceException: customMessage";
            }
            else
            {
                customMessage = _commandBus.Validate(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Plugin_CrudServices.Cmd_Validate(cmd) | _commandBus.Validate(cmd) = null returned";
                }
            }

            return customMessage;
        }

        private CustomMessage Cmd_Submit(PluginCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Plugin_CrudServices.Cmd_Submit(cmd) - ArgumentNullException";
            }
            else
            {
                customMessage = _commandBus.Submit(cmd);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Plugin_CrudServices.Cmd_Submit(cmd) - commandBus.Submit(cmd) - NullReferenceException: customMessage";
                }
            }

            return customMessage;
        }

        public virtual PluginCmd Cmd_Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            PluginCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "PluginCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                Plugin dao = _repository.Create(out customMessage1);

                if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "PluginCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('dao')";
                }
                else
                {
                    cmd = _mapper.GetCmdFromDao(dao);

                    if (cmd == null)
                    {
                        customMessage1.IsErrorCondition = true;
                        customMessage1.Message = "PluginCrudServices.Cmd_Create() |  _repository.Create() - NullReferenceException('cmd')";
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

        public virtual PluginCmd Cmd_SetDefaultPropertyValues(PluginCmd cmd, string userName)
        {
            if (cmd == null)
                return null;

            if (string.IsNullOrEmpty(userName))
                return null;

            cmd.IsActive = true;

            cmd = SetAddProperties(cmd, userName);

            return cmd;
        }

        private PluginCmd SetAddProperties(PluginCmd cmd, string userName)
        {
            if (cmd != null)
            {
                cmd.AddedBy = userName;
                cmd.AddedDate = _dateTimeAdapter.UtcNow;
                cmd = SetUpdateProperties(cmd, userName);
            }
            return cmd;
        }

        private PluginCmd SetDeleteProperties(PluginCmd cmd, string userName)
        {
            if (cmd != null)
            {
                // POLICY: branch logic to set entity.IsDeleted or to execute IDbSet<>.Remove(TEntity entity);
                cmd.IsDeleted = true;
                cmd.IsActive = false;
                cmd = SetUpdateProperties(cmd, userName);
            }
            return cmd;
        }

        private PluginCmd SetUpdateProperties(PluginCmd cmd, string userName)
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
