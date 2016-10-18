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
    public class Country_ValidationHandler : IValidationHandler<CountryCmd>
    {
        #region Private Fields

        private readonly ICountry_Queries _queries;

        #endregion

        #region ctor

        public Country_ValidationHandler(ICountry_Queries service)
        {
            this._queries = service;
        }

        #endregion

        #region Methods

        public CustomMessage Validate(CountryCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Country_ValidationHandler.Validate(cmd) - ArgumentNullException";

            }
            else
            {
                // required field
                if (string.IsNullOrEmpty(cmd.Abbreviation))
                    customMessage.MessageDictionary2.Add("Abbreviation", ValidationMessages.AbbreviationIsRequired);
                // required field
                if (string.IsNullOrEmpty(cmd.DisplayName))
                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DisplayNameIsRequired);
                
                if (cmd.Id == 0)
                {
                    // adding
                    if (_queries.HasAbbreviation(cmd.Abbreviation))
                        customMessage.MessageDictionary2.Add("Abbreviation", ValidationMessages.DuplicateAbbreviationFound);
                    if (_queries.HasDisplayName(cmd.DisplayName))
                        customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                }
                else
                {
                    // deleting or updating
                    CountryDto dto = _queries.Get(a => a.Id == cmd.Id);

                    if (dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> Country_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.Abbreviation != cmd.Abbreviation)
                        {
                            IEnumerable<CountrySummary> list = _queries.GetSummaryList(a => a.Abbreviation == cmd.Abbreviation);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("Abbreviation", ValidationMessages.DuplicateAbbreviationFound);
                            }
                        }
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<CountrySummary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
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

