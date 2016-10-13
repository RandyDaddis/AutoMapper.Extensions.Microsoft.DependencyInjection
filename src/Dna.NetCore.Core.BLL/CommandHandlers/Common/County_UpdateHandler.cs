using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.CommandProcessing;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class County_UpdateHandler : ICommandHandler<CountyCmd>
    {
        #region Private Fields

        private readonly ICountyRepository _repository;
        private readonly ICountyMapper _mapper;

        #endregion

        #region ctor

        //public delegate County_UpdateHandler Factory();

        //public County_UpdateHandler()
        //{
        //    _repository = Ioc.Resolve<ICountyRepository>();
        //    if (_repository == null) throw new Exception("County_UpdateHandler() - unable to resolve Ioc.Resolve<ICountyRepository>()");
        //    _mapper = Ioc.Resolve<ICountyMapper>();
        //    if (_mapper == null) throw new Exception("County_UpdateHandler() - unable to resolve Ioc.Resolve<ICountyMapper>()");
        //}

        public County_UpdateHandler(ICountyRepository repository,
                                        ICountyMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(CountyCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> County_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                County dao = _mapper.GetDaoFromCmd(cmd);

                if (dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> County_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        County stateOrProvince = _repository.Add(dao, out customMessage);

                        if (customMessage.IsErrorCondition == false && stateOrProvince != null)
                        {
                            numberOfChanges = _repository.SaveChanges(out customMessage);

                            if (numberOfChanges > 0)
                                customMessage.MessageDictionary1.Add("AddId", stateOrProvince.Id.ToString());
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
