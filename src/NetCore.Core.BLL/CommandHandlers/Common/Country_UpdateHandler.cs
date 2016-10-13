﻿using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.CommandProcessing;
using System.Collections.Generic;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class Country_UpdateHandler : ICommandHandler<CountryCmd>
    {
        #region Private Fields

        private readonly ICountryRepository _repository;
        private readonly ICountryMapper _mapper;

        #endregion

        #region ctor

        //public delegate Country_UpdateHandler Factory();

        //public Country_UpdateHandler()
        //{
        //    _repository = Ioc.Resolve<ICountryRepository>();
        //    if (_repository == null) throw new Exception("Country_UpdateHandler() - unable to resolve Ioc.Resolve<ICountryRepository>()");
        //    _mapper = Ioc.Resolve<ICountryMapper>();
        //    if (_mapper == null) throw new Exception("Country_UpdateHandler() - unable to resolve Ioc.Resolve<ICountryMapper>()");
        //}

        public Country_UpdateHandler(ICountryRepository repository,
                                        ICountryMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(CountryCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Country_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                Country dao = _mapper.GetDaoFromCmd(cmd);

                if ((Country)dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Country_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        Country dao2 = _repository.Add(dao, out customMessage);

                        if (customMessage.IsErrorCondition == false && (Country)dao2 != null)
                        {
                            numberOfChanges = _repository.SaveChanges(out customMessage);

                            if (numberOfChanges > 0)
                                customMessage.MessageDictionary1.Add("AddId", dao2.Id.ToString());
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