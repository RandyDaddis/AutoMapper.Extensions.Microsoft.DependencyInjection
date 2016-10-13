using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.CommandProcessing;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Common
{
    public class StateOrProvince_UpdateHandler : ICommandHandler<StateOrProvinceCmd>
    {
        #region Private Fields

        private readonly IStateOrProvinceRepository _repository;
        private readonly IStateOrProvinceMapper _mapper;

        #endregion

        #region ctor

        //public delegate StateOrProvince_UpdateHandler Factory();

        //public StateOrProvince_UpdateHandler()
        //{
        //    _repository = Ioc.Resolve<IStateOrProvinceRepository>();
        //    if (_repository == null) throw new Exception("StateOrProvince_UpdateHandler() - unable to resolve Ioc.Resolve<IStateOrProvinceRepository>()");
        //    _mapper = Ioc.Resolve<IStateOrProvinceMapper>();
        //    if (_mapper == null) throw new Exception("StateOrProvince_UpdateHandler() - unable to resolve Ioc.Resolve<IStateOrProvinceMapper>()");
        //}

        public StateOrProvince_UpdateHandler(IStateOrProvinceRepository repository,
                                        IStateOrProvinceMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(StateOrProvinceCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> StateOrProvince_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                StateOrProvince dao = _mapper.GetDaoFromCmd(cmd);

                if (dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> StateOrProvince_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        StateOrProvince stateOrProvince = _repository.Add(dao, out customMessage);

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
