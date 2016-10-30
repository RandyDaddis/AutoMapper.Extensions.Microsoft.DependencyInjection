using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Resources;
using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class County_ValidationHandler : IValidationHandler<CountyCmd>
    {
        #region Private Fields

        private readonly ICounty_Queries _queries;

        #endregion

        #region ctor

        public County_ValidationHandler(ICounty_Queries service)
        {
            this._queries = service;
        }

        #endregion

        #region Methods

        public CustomMessage Validate(CountyCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> County_ValidationHandler.Validate(cmd) - ArgumentNullException";

            }
            else
            {
                // required field
                if (string.IsNullOrEmpty(cmd.DisplayName))
                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DisplayNameIsRequired);

                if (cmd.Id == 0)
                {
                    // adding
                    if (_queries.HasDisplayName(cmd.DisplayName))
                        customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                }
                else
                {
                    // deleting or updating
                    CountyDto dto = _queries.Get(cmd.Id);

                    if (dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> County_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<CountySummary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                            }
                        }
                    }
                }

                // Ascendent Dependencies
                if (cmd.StateOrProvinceId < 1)
                    customMessage.MessageDictionary2.Add("StateOrProvinceId", ValidationMessages.StateOrProvinceIsRequired);

                // Base Properties
                if (string.IsNullOrEmpty(cmd.AddedBy))
                    customMessage.MessageDictionary2.Add("AddedBy", ValidationMessages.AddedByIsRequired);

                if ((DateTime)cmd.AddedDate == null)
                    customMessage.MessageDictionary2.Add("AddedDate", ValidationMessages.AddedDateIsRequired);

                if (string.IsNullOrEmpty(cmd.ChangedBy))
                    customMessage.MessageDictionary2.Add("ChangedBy", ValidationMessages.ChangedByIsRequired);

                if ((DateTime)cmd.ChangedDate == null)
                    customMessage.MessageDictionary2.Add("ChangedDate", ValidationMessages.ChangedDateIsRequired);
            }

            if (customMessage.MessageDictionary2.Count > 0)
                customMessage.IsErrorCondition = true;

            return customMessage;
        }

        #endregion
    }
}

