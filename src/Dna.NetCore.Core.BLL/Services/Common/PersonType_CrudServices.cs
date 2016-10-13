using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class PersonType_CrudServices : IPersonType_CrudServices
    {
        #region Fields

        private readonly IPersonTypeRepository _customerTypeRepository;
        protected readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        //public delegate PersonType_CrudServices Factory();

        //public PersonType_CrudServices()
        //{
        //    _customerTypeRepository = Ioc.Resolve<IPersonTypeRepository>();
        //    if (_customerTypeRepository == null)
        //        throw new Exception("PersonType_CrudServices() - unable to resolve Ioc.Resolve<IPersonTypeRepository>()");
        //}

        public PersonType_CrudServices(IPersonTypeRepository customerTypeRepository, IDateTimeAdapter dateTimeAdapter)
        {
            _customerTypeRepository = customerTypeRepository;
            _dateTimeAdapter = dateTimeAdapter;

        }

        #endregion

        #region CRUD Methods

        public void Add(List<PersonType> list, out CustomMessage customMessage)
        {
            CustomMessage customMessage2 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            foreach (var entity in list)
            {
                CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                Add(entity, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage()
                    {
                        MessageDictionary1 = new Dictionary<string, string>(),
                        MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true,
                        Message = "-->> PersonType_CrudServices.Add(List<PersonType> list, out CustomMessage customMessage) - Add(entity, out customMessage1); - null customMessage1 returned"
                    };
                else
                {
                    if (customMessage1.MessageDictionary1 != null)
                        foreach (var element in customMessage1.MessageDictionary1)
                            customMessage2.MessageDictionary1.Add(element.Key, element.Value);

                    if (customMessage1.MessageDictionary2 != null)
                        foreach (var element in customMessage1.MessageDictionary2)
                            customMessage2.MessageDictionary2.Add(element.Key, element.Value);
                }
            }

            customMessage = customMessage2;
        }

        public virtual void Add(PersonType dao, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((PersonType)dao == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> PersonType_CrudServices.Add(dao) - ArgumentNullException";
            }
            else
            {
                PersonType entity = _customerTypeRepository.Add(dao, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage()
                    {
                        MessageDictionary1 = new Dictionary<string, string>(),
                        MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true,
                        Message = "-->> PersonType_CrudServices.Add(entity, out customMessage1); - null customMessage1 returned"
                    };

                if ((PersonType)entity == null)
                {
                    customMessage1.MessageDictionary2.Add("PersonTypeRepository.Add(dao) - null entity returned", entity.SystemName);
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> PersonTypeRepository.Add(dao) - null returned" + customMessage1.Message;
                }
                else
                {
                    int numberOfChanges = _customerTypeRepository.SaveChanges(out customMessage1);

                    if (customMessage1 == null)
                        customMessage1 = new CustomMessage()
                        {
                            MessageDictionary1 = new Dictionary<string, string>(),
                            MessageDictionary2 = new Dictionary<string, string>(),
                            IsErrorCondition = true,
                            Message = "-->> PersonType_CrudServices.Add(entity, out customMessage1); - _customerTypeRepository.SaveChanges(out customMessage1); - null customMessage1 returned"
                        };

                    if (numberOfChanges > 0 && customMessage1.IsErrorCondition == false)
                        customMessage1.MessageDictionary1.Add("AddId", entity.Id.ToString());
                }
            }
            customMessage = customMessage1;

            return;
        }

        public virtual PersonType Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            PersonType dao = null;

            dao = _customerTypeRepository.Create(out customMessage1);

            if (customMessage1 == null)
            {
                customMessage1 = new CustomMessage()
                {
                    MessageDictionary1 = new Dictionary<string, string>(),
                    MessageDictionary2 = new Dictionary<string, string>(),
                    IsErrorCondition = true,
                    Message = "-->> PersonType_CrudServices.Create(string userName, out CustomMessage customMessage) - _customerTypeRepository.Create(out customMessage1); - Add(entity, out customMessage1); - null customMessage1 returned"
                };
            }
            else if ((PersonType)dao == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "PersonType_CrudServices.Create() |  IPersonTypeRepository.Create() - Null returned";
            }
            else
            {
                SetDefaultPropertyValues(dao, userName);
            }

            customMessage = customMessage1;

            return dao;
        }

        public virtual PersonType Create(string userName, out CustomMessage customMessage,
                                                string systemName, string displayName,
                                                bool isActive = true)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            PersonType dao = Create(userName, out customMessage1);

            if (customMessage1 == null)
            {
                customMessage1 = new CustomMessage()
                {
                    MessageDictionary1 = new Dictionary<string, string>(),
                    MessageDictionary2 = new Dictionary<string, string>(),
                    IsErrorCondition = true,
                    Message = "-->> PersonType_CrudServices.Create(string userName, out CustomMessage customMessage) - _customerTypeRepository.Create(out customMessage1); - Add(entity, out customMessage1); - null customMessage1 returned"
                };
            }
            else if ((PersonType)dao != null)
            {
                dao = SetPropertyValues(dao, systemName, displayName, isActive);
            }

            customMessage = customMessage1;

            return dao;
        }

        #endregion

        #region Helper Methods

        public virtual PersonType SetAddPropertyValues(PersonType dao, string userName)
        {
            dao.AddedBy = userName;
            dao.AddedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }

        public virtual PersonType SetDeletePropertyValues(PersonType dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;
            dao.IsDeleted = true;

            return dao;
        }

        public virtual PersonType SetUpdatePropertyValues(PersonType dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }
        public virtual PersonType SetDefaultPropertyValues(PersonType dao, string userName)
        {
            // TODO: base.SetDefaultPropertyValues(dao, userName); 
            //                                      is duplicated in BaseEntity().SetDefaultBasePropertyValues<T>(T dao, string userName) & 
            //                                                       CrudServices_Base_EntityType_Parent<P>.SetDefaultPropertyValues(P dao, string userName)
            dao = SetAddPropertyValues(dao, userName);
            dao = SetUpdatePropertyValues(dao, userName);

            return dao;
        }

        public virtual PersonType SetPropertyValues(PersonType dao,
                                        string systemName, string displayName,
                                        bool isActive = true)
        {
            dao.SystemName = systemName;
            dao.DisplayName = displayName;
            dao.IsActive = isActive;

            return dao;
        }

        #endregion
    }
}
