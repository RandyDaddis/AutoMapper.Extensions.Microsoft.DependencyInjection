using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.Mappers.Plugins;
using Dna.NetCore.Core.BLL.Repositories.Plugins;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Plugins
{
    public class Plugin_UpdateHandler : ICommandHandler<PluginCmd>
    {
        #region Private Fields

        private readonly IPluginRepository _repository;
		private readonly IPluginMapper _mapper;

		#endregion

		#region ctor

        public Plugin_UpdateHandler(IPluginRepository repository,
                                    IPluginMapper mapper)
		{
            _repository = repository;
			_mapper = mapper;
		}

		#endregion

		#region Methods

        public CustomMessage Execute(PluginCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Plugin_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                Plugin dao = _mapper.GetDaoFromCmd(cmd);

                if (dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Plugin_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        Plugin dao2 = _repository.Add(dao, out customMessage);

                        if (customMessage.IsErrorCondition == false) // && dao2 != null) // temporary workaround until .NET Core 2.0 is analyzed
                        {
                            numberOfChanges = _repository.SaveChanges(out customMessage);

                            if (numberOfChanges > 0)
                                customMessage.MessageDictionary1.Add("AddId", "1"); // dao2.Id.ToString()); // temporary workaround until .NET Core 2.0 is analyzed
                        }
                    }
                    else
                    {
                        if (dao.IsDeleted == true)
                        {
                            bool permanentDeletion = true; // TODO: persist delete policy

                            if (permanentDeletion)
                                _repository.Remove(dao, out customMessage);
                            else
                                _repository.Update(dao, out customMessage);

                            if (!customMessage.IsErrorCondition)
                                customMessage.MessageDictionary1.Add("DeleteId", "1"); // dao.Id.ToString());
                        }
                        else
                        {
                            _repository.Update(dao, out customMessage);
                        }

                        if (customMessage.IsErrorCondition == false)
                            numberOfChanges = _repository.SaveChanges(out customMessage);
                    }
                }
            }
            customMessage.MessageDictionary1.Add("numberOfChanges", numberOfChanges.ToString());

            return customMessage;
        }

        #endregion
    }
}
