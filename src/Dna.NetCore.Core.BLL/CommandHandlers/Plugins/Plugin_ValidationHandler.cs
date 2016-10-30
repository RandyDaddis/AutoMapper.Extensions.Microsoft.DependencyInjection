using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Resources;
using Dna.NetCore.Core.BLL.Services.Plugins;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Plugins
{
    public class Plugin_ValidationHandler : IValidationHandler<PluginCmd>
    {
        #region Private Fields

        private readonly IPlugin_Queries _queries;

		#endregion

		#region ctor

        public Plugin_ValidationHandler(IPlugin_Queries service)
		{
            _queries = service;
		}

		#endregion

		#region Methods

        public CustomMessage Validate(PluginCmd cmd)
		{
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Plugin_ValidationHandler.Validate(cmd) - ArgumentNullException";
            }
            else
            {
                // required field
                if (string.IsNullOrEmpty(cmd.SystemName))
                    customMessage.MessageDictionary2.Add("SystemName", ValidationMessages.SystemNameIsRequired);
                // required field
                if (string.IsNullOrEmpty(cmd.DisplayName))
                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DisplayNameIsRequired);

                if (cmd.Id == 0)
                {
                    // adding
                    if (_queries.HasSystemName(cmd.SystemName))
                        customMessage.MessageDictionary2.Add("SystemName", ValidationMessages.DuplicateSystemNameFound);
                    if (_queries.HasDisplayName(cmd.DisplayName))
                        customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                }
                else
                {
                    // deleting or updating
                    PluginDto dto = _queries.Get(a => a.Id == cmd.Id);

                    if (dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> Plugin_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.SystemName != cmd.SystemName)
                        {
                            IEnumerable<PluginSummary> list = _queries.GetSummaryList(a => a.SystemName == cmd.SystemName);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("SystemName", ValidationMessages.DuplicateSystemNameFound);
                            }
                        }
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<PluginSummary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                            }
                        }
                    }
                }
                // Base Properties
                if (string.IsNullOrEmpty(cmd.AddedBy))
                    customMessage.MessageDictionary2.Add("AddedBy", ValidationMessages.AddedByIsRequired);

                if (cmd.AddedDate == null)
                    customMessage.MessageDictionary2.Add("AddedDate", ValidationMessages.AddedDateIsRequired);

                if (string.IsNullOrEmpty(cmd.ChangedBy))
                    customMessage.MessageDictionary2.Add("ChangedBy", ValidationMessages.ChangedByIsRequired);

                if (cmd.ChangedDate == null)
                    customMessage.MessageDictionary2.Add("ChangedDate", ValidationMessages.ChangedDateIsRequired);
            }

            if (customMessage.MessageDictionary2.Count > 0)
                customMessage.IsErrorCondition = true;

            return customMessage;
        }

		#endregion
	}
}

