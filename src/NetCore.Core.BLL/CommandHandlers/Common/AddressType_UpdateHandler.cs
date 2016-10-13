﻿using NetCore.Core.BLL.Commands.Common;
using NetCore.Core.BLL.Entities.Common;
using NetCore.Core.BLL.Mappers.Common;
using NetCore.Core.BLL.Repositories.Common;
using NetCore.Core.CommandProcessing;
using NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class AddressType_UpdateHandler : ICommandHandler<AddressTypeCmd>
    {
        #region Private Fields

        private readonly IAddressTypeRepository _repository;
        private readonly IAddressTypeMapper _mapper;

        #endregion

        #region ctor

        public AddressType_UpdateHandler(IAddressTypeRepository repository,
                                         IAddressTypeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(AddressTypeCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> AddressType_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                AddressType dao = _mapper.GetDaoFromCmd(cmd);

                if (dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> AddressType_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        AddressType address = _repository.Add(dao, out customMessage);

                        if (customMessage.IsErrorCondition == false && address != null)
                        {
                            numberOfChanges = _repository.SaveChanges(out customMessage);

                            if (numberOfChanges > 0)
                                customMessage.MessageDictionary1.Add("AddId", address.Id.ToString());
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
                                customMessage.MessageDictionary1.Add("DeleteId", dao.Id.ToString());
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
