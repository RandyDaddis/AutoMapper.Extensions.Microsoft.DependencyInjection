using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Resources;
using Dna.NetCore.Core.BLL.Services.Localization;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Localization
{
    public class Locale_ValidationHandler : IValidationHandler<LocaleCmd>
    {
        #region Private Fields

        private readonly ILocale_Queries _queries;

		#endregion

		#region ctor

        public Locale_ValidationHandler(ILocale_Queries service)
		{
            _queries = service;
		}

		#endregion

		#region Methods

        public CustomMessage Validate(LocaleCmd cmd)
		{
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Locale_ValidationHandler.Validate(cmd) - ArgumentNullException";
            }
            else
            {
                // required field
                if (string.IsNullOrEmpty(cmd.DisplayName))
                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DisplayNameIsRequired);
                // required field
                //if (cmd.LCIDDecimal == 0)  // DEVNOTE: "Unicode", "", "UTF-8", 0, 0, 0 is valid
                //    yield return new ValidationResult(ValidationMessages.LCIDDecimalIsRequired, new[] { "LCIDDecimal" });
                if (cmd.Id == 0)
                {
                    // adding
                    //    if (_queries.HasName(cmd.Name))  // DEVNOTE: duplicate names are allowed - HasLCIDDecimal is unique
                    //        yield return new ValidationResult(ValidationMessages.DuplicateNameFound, new[] { "Name" });
                    if (_queries.HasLCIDDecimal(cmd.LCIDDecimal))
                        customMessage.MessageDictionary2.Add("LCIDDecimal", ValidationMessages.DuplicateLCIDDecimalFound);
                }
                else
                {
                    // deleting or updating
                    LocaleDto dto = _queries.Get(x => x.Id == cmd.Id);

                    if ((LocaleDto)dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> Locale_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<Locale_Summary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                            }
                        }
                        // unique property validation
                        if (dto.LCIDDecimal != cmd.LCIDDecimal)
                        {
                            IEnumerable<Locale_Summary> list = _queries.GetSummaryList(a => a.LCIDDecimal == cmd.LCIDDecimal);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("LCIDDecimal", ValidationMessages.DuplicateLCIDDecimalFound);
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

