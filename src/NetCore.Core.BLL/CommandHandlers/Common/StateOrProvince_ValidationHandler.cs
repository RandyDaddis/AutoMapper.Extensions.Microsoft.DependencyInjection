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
    public class StateOrProvince_ValidationHandler : IValidationHandler<StateOrProvinceCmd>
    {
        #region Private Fields

        private readonly IStateOrProvince_Queries _queries;

        #endregion

        #region ctor

        //public delegate StateOrProvince_ValidationHandler Factory();

        //public StateOrProvince_ValidationHandler()
        //{
        //    _queries = Ioc.Resolve<IStateOrProvince_Queries>();
        //    if (_queries == null) throw new Exception("StateOrProvince_ValidationHandler() - unable to resolve  Ioc.Resolve<IStateOrProvinceService>()");
        //}

        public StateOrProvince_ValidationHandler(IStateOrProvince_Queries service)
        {
            this._queries = service;
        }

        #endregion

        #region Methods

        public CustomMessage Validate(StateOrProvinceCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> StateOrProvince_ValidationHandler.Validate(cmd) - ArgumentNullException";

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
                    if (_queries.HasName(cmd.DisplayName))
                        customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                }
                else
                {
                    // deleting or updating
                    StateOrProvinceDto dto = _queries.Get(a => a.Id == cmd.Id);

                    if (dto == null)
                    {
                        customMessage.MessageDictionary2.Add(" -->> StateOrProvince_ValidationHandler.Validate(cmd) | _queries.Get(cmd.Id)", ValidationMessages.RecordNotFound);
                    }
                    else
                    {
                        // unique property validation
                        if (dto.Abbreviation != cmd.Abbreviation)
                        {
                            IEnumerable<StateOrProvince_Summary> list = _queries.GetSummaryList(a => a.Abbreviation == cmd.Abbreviation);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("Abbreviation", ValidationMessages.DuplicateAbbreviationFound);
                            }
                        }
                        // unique property validation
                        if (dto.DisplayName != cmd.DisplayName)
                        {
                            IEnumerable<StateOrProvince_Summary> list = _queries.GetSummaryList(a => a.DisplayName == cmd.DisplayName);
                            foreach (var item in list)
                            {
                                if (item.Id != cmd.Id)
                                    customMessage.MessageDictionary2.Add("DisplayName", ValidationMessages.DuplicateDisplayNameFound);
                            }
                        }
                    }
                }

                // Ascendent Dependencies
                if (cmd.CountryId < 1)
                    customMessage.MessageDictionary2.Add("CountryId", ValidationMessages.CountryIsRequired);

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

