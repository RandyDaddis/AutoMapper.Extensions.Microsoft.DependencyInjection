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
    public class Currency_ValidationHandler : IValidationHandler<CurrencyCmd>
    {
        #region Private Fields

        private readonly ICurrency_Queries _queries;

        #endregion

        #region ctor

        public Currency_ValidationHandler(ICurrency_Queries service)
        {
            this._queries = service;
        }

        #endregion

        #region Methods

        public CustomMessage Validate(CurrencyCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Currency_ValidationHandler.Validate(cmd) - ArgumentNullException";
            }
            else
            {
                // required field
                if (string.IsNullOrEmpty(cmd.Code))
                    customMessage.MessageDictionary2.Add("Code", ValidationMessages.CodeIsRequired);
               // required field
                if (string.IsNullOrEmpty(cmd.DisplayName))
                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DisplayNameIsRequired);

                if (cmd.Id == 0)
                {
                    // adding
                    if (_queries.HasCode(cmd.Code))
                        customMessage.MessageDictionary2.Add("Code", ValidationMessages.DuplicateCodeFound);

                    if (_queries.HasName(cmd.DisplayName))
                        customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                }
                else
                {
                    // deleting or updating
                    CurrencyDto dto = _queries.Get(x => x.Id == cmd.Id);

                    if ((CurrencyDto)dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> Currency_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.Code != cmd.Code)
                        {
                            IEnumerable<Currency_Summary> list = _queries.GetSummaryList(a => a.Code == cmd.Code);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("Code", ValidationMessages.DuplicateCodeFound);
                            }
                        }
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<Currency_Summary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
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

