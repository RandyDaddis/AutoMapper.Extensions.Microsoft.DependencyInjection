using dao = Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class TimeZone_CrudServices : ITimeZone_CrudServices
    {
        #region Fields

        private readonly ITimeZoneRepository _repository;
        private readonly ITimeZoneMapper _mapper;
        protected readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        //public delegate TimeZone_CrudServices Factory();

        //public TimeZone_CrudServices()
        //{
        //    _repository = Ioc.Resolve<ITimeZoneRepository>();
        //    if (_repository == null)
        //        throw new Exception("TimeZone_CrudServices() - unable to resolve Ioc.Resolve<ITimeZoneRepository>()");

        //    _mapper = Ioc.Resolve<ITimeZoneMapper>();
        //    if (_mapper == null)
        //        throw new Exception("TimeZone_CrudServices() - unable to resolve Ioc.Resolve<ITimeZoneMapper>()");

        //}

        public TimeZone_CrudServices(ITimeZoneRepository repository,
                                        ITimeZoneMapper mapper,
                                        IDateTimeAdapter dateTimeAdapter)
        {
            _repository = repository;
            _mapper = mapper;
            _dateTimeAdapter = dateTimeAdapter;

        }

        #endregion

        #region CRUD Methods

        public void Add(List<dao.TimeZone> list, out CustomMessage customMessage)
        {
            CustomMessage customMessage2 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            foreach (var entity in list)
            {
                CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                Add(entity, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                                                            IsErrorCondition = true, Message = "-->> TimeZone_CrudServices.Add(List<dao.TimeZone> list, out CustomMessage customMessage) - Add(entity, out customMessage1); - null customMessage1 returned"};
                else
                {
                    if (customMessage1.MessageDictionary1 != null && customMessage1.MessageDictionary1.Count > 0)
                        foreach (var element in customMessage1.MessageDictionary1)
                        {
                            if (customMessage2.MessageDictionary1.ContainsKey(element.Key))
                            {
                                int count = int.Parse(customMessage2.MessageDictionary1[element.Key]);
                                count++;
                                customMessage2.MessageDictionary1[element.Key] = count.ToString();
                            }
                            else
                            {
                                customMessage2.MessageDictionary1.Add(element.Key, element.Value);
                            }

                        }

                    if (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count > 0)
                        foreach (var element in customMessage1.MessageDictionary2)
                        {
                            if (customMessage2.MessageDictionary2.ContainsKey(element.Key))
                            {
                                int count = int.Parse(customMessage2.MessageDictionary2[element.Key]);
                                count++;
                                customMessage2.MessageDictionary2[element.Key] = count.ToString();
                            }
                            else
                            {
                                customMessage2.MessageDictionary2.Add(element.Key, element.Value);
                            }

                        }
                }
            }

            customMessage = customMessage2;
        }

        public virtual void Add(dao.TimeZone dao, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dao == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> TimeZone_CrudServices.Add(dao) - ArgumentNullException";
            }
            else
            {
                dao.TimeZone entity = _repository.Add(dao, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true, Message = "-->> TimeZone_CrudServices.Add(entity, out customMessage1); - null customMessage1 returned"};

                if (entity == null)
                {
                    customMessage1.MessageDictionary2.Add("TimeZone_Failure", "1");
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> TimeZoneRepository.Add(dao) - null returned" + customMessage1.Message;
                }
                else
                {
                    int numberOfChanges = _repository.SaveChanges(out customMessage1);

                    if (customMessage1 == null)
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                            IsErrorCondition = true, Message = "-->> TimeZone_CrudServices.Add(entity, out customMessage1); - TimeZoneRepository.SaveChanges(out customMessage1); - null customMessage1 returned"};

                    if (numberOfChanges > 0 && customMessage1.IsErrorCondition == false)
                        customMessage1.MessageDictionary1.Add("TimeZone_Success", "1");
                    else
                        customMessage1.MessageDictionary2.Add("TimeZone_Failure", "1");
                }
            }
            customMessage = customMessage1;

            return;
        }

        public virtual dao.TimeZone Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            dao.TimeZone dao = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "TimeZoneCrudServices.Create() - ArgumentNullException('userName')";
            }
            else
            {
                dao = _repository.Create(out customMessage1);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage()
                    {
                        MessageDictionary1 = new Dictionary<string, string>(),
                        MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true,
                        Message = "-->> TimeZone_CrudServices.Create(string userName, out CustomMessage customMessage) - TimeZoneRepository.Create(out customMessage1); - Add(entity, out customMessage1); - null customMessage1 returned"
                    };
                }
                else if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "TimeZone_CrudServices.Create() |  TimeZoneRepository.Create() - Null returned";
                }
                else
                {
                    dao = SetDefaultPropertyValues(dao, userName);
                }
            }
            customMessage = customMessage1;
            return dao;
        }

        public virtual TimeZoneCmd Cmd_Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            TimeZoneCmd cmd = null;

            if (string.IsNullOrEmpty(userName))
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "TimeZoneCrudServices.Cmd_Create() - ArgumentNullException('userName')";
            }
            else
            {
                dao.TimeZone dao = _repository.Create(out customMessage1);

                if (dao == null)
                {
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = "TimeZone_CrudServices.Create() |  TimeZoneRepository.Create() - Null returned";
                }
                else
                {
                    dao = SetDefaultPropertyValues(dao, userName);
                    cmd = _mapper.GetCmdFromDao(dao);
                }
            }

            customMessage = customMessage1;

            return cmd;
        }

        #endregion

        #region Helper Methods

        public virtual dao.TimeZone SetAddPropertyValues(dao.TimeZone dao, string userName)
        {
            dao.AddedBy = userName;
            dao.AddedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }

        public virtual dao.TimeZone SetDeletePropertyValues(dao.TimeZone dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;
            dao.IsDeleted = true;

            return dao;
        }

        public virtual dao.TimeZone SetUpdatePropertyValues(dao.TimeZone dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }
        public virtual TimeZoneCmd Cmd_SetPropertyValues(TimeZoneCmd cmd,
                                                            string timeZoneInfoId, string daylightName,
                                                            string displayName, string standardName,
                                                            bool supportsDaylightSavingTime = true,
                                                            bool isActive = true)
        {
            if (cmd == null)
                return null;

            cmd.TimeZoneInfoId = timeZoneInfoId;
            cmd.DaylightName = daylightName;
            cmd.DisplayName = displayName;
            cmd.StandardName = standardName;
            cmd.SupportsDaylightSavingTime = supportsDaylightSavingTime;
            cmd.IsActive = true;

            return cmd;
        }

        public virtual dao.TimeZone SetPropertyValues(dao.TimeZone dao,
                                                            string timeZoneInfoId, string daylightName,
                                                            string displayName, string standardName,
                                                            bool supportsDaylightSavingTime = true,
                                                            bool isActive = true)
        {
            if (dao == null)
                return null;

            dao.TimeZoneInfoId = timeZoneInfoId;
            dao.DaylightName = daylightName;
            dao.DisplayName = displayName;
            dao.StandardName = standardName;
            dao.SupportsDaylightSavingTime = supportsDaylightSavingTime;
            dao.IsActive = true;

            return dao;
        }

        public dao.TimeZone SetDefaultPropertyValues(dao.TimeZone dao, string userName)
        {
            if (dao == null)
                return null;

            dao.SupportsDaylightSavingTime = true;
            dao.IsActive = true;

            SetAddPropertyValues(dao, userName);
            SetUpdatePropertyValues(dao, userName);

            return dao;
        }

        #endregion

    }
}
