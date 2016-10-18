using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.BLL.Resources;
using Dna.NetCore.Core.CommandProcessing;
using System;
using System.Collections.Generic;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class City_ValidationHandler : IValidationHandler<CityCmd>
    {
        #region Private Fields

        private readonly ICity_Queries _queries;

        #endregion

        #region ctor

        public City_ValidationHandler(ICity_Queries service)
        {
            this._queries = service;
        }

        #endregion

        #region Methods

        public CustomMessage Validate(CityCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> City_ValidationHandler.Validate(cmd) - ArgumentNullException";

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
                    CityDto dto = _queries.Get(cmd.Id);

                    if (dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> City_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<CitySummary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
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

