using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Repositories.Localization;
using Dna.NetCore.Core.BLL.Mappers.Localization;
using Dna.NetCore.Core.CommandProcessing;
using System.Collections.Generic;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.CommandHandlers.Localization
{
    public class Locale_UpdateHandler : ICommandHandler<LocaleCmd>
    {
        #region Private Fields

        private readonly ILocaleRepository _repository;
		private readonly ILocaleMapper _mapper;

		#endregion

		#region ctor

        public Locale_UpdateHandler(ILocaleRepository repository,
                                        ILocaleMapper mapper)
		{
            _repository = repository;
			_mapper = mapper;
		}

		#endregion

		#region Methods

        public CustomMessage Execute(LocaleCmd cmd)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            if (cmd == null)
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = " -->> Locale_UpdateHandler.Execute(cmd) - ArgumentNullException";
            }
            else
            {
                Locale dao = _mapper.GetDaoFromCmd(cmd);

                if (dao == null)
                {
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = " -->> Locale_UpdateHandler.Execute(cmd) | _mapper.GetDaoFromCmd(cmd) - returned null";
                }
                else
                {
                    if (cmd.Id == 0)
                    {
                        Locale dto2 = _repository.Add(dao, out customMessage);

                        if (customMessage.IsErrorCondition == false) // && dto2 != null) // temporary workaround until .NET Core 2.0 is analyzed
                        {
                            numberOfChanges = _repository.SaveChanges(out customMessage);

                            if (numberOfChanges > 0)
                                customMessage.MessageDictionary1.Add("AddId", "1"); // dto2.Id.ToString()); // temporary workaround until .NET Core 2.0 is analyzed
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
                                customMessage.MessageDictionary1.Add("DeleteId", "1"); // dao.Id.ToString());
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
