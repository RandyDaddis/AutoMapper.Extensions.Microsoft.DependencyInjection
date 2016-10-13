using Dna.NetCore.Core.BLL.Constants;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class SystemSetting_CrudServices : ISystemSetting_CrudServices
    {
        #region Fields

        private readonly ISystemSettingRepository _repository;
        protected readonly ISystemSetting_Queries _systemSettingQueries;
        protected readonly IDateTimeAdapter _dateTimeAdapter;

        #endregion

        #region ctor

        //public delegate SystemSetting_CrudServices Factory();

        //public SystemSetting_CrudServices()
        //{
        //    _repository = Ioc.Resolve<ISystemSettingRepository>();
        //    if (_repository == null)
        //        throw new Exception("SystemSetting_CrudServices() - unable to resolve Ioc.Resolve<ISystemSettingRepository>()");

        //}

        public SystemSetting_CrudServices(ISystemSettingRepository repository,
                                            ISystemSetting_Queries systemSettingQueries,
                                            IDateTimeAdapter dateTimeAdapter)
        {
            _repository = repository;
            _systemSettingQueries = systemSettingQueries;
            _dateTimeAdapter = dateTimeAdapter;

        }

        #endregion

        #region CRUD Methods

        public void Add(List<SystemSetting> list, out CustomMessage customMessage)
        {
            CustomMessage customMessage2 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            foreach (var entity in list)
            {
                CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                Add(entity, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                                                            IsErrorCondition = true, Message = "-->> SystemSetting_CrudServices.Add(List<SystemSetting> list, out CustomMessage customMessage) - Add(entity, out customMessage1); - null customMessage1 returned"};
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

        public virtual void Add(SystemSetting dao, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (dao == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = " -->> SystemSetting_CrudServices.Add(dao) - ArgumentNullException";
            }
            else
            {
                SystemSetting entity = _repository.Add(dao, out customMessage1);

                if (customMessage1 == null)
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true, Message = "-->> SystemSetting_CrudServices.Add(entity, out customMessage1); - null customMessage1 returned"};

                if (entity == null)
                {
                    customMessage1.MessageDictionary2.Add("SystemSetting_Failure", "1");
                    customMessage1.IsErrorCondition = true;
                    customMessage1.Message = " -->> SystemSettingRepository.Add(dao) - null returned" + customMessage1.Message;
                }
                else
                {
                    int numberOfChanges = _repository.SaveChanges(out customMessage1);

                    if (customMessage1 == null)
                        customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>(),
                            IsErrorCondition = true, Message = "-->> SystemSetting_CrudServices.Add(entity, out customMessage1); - SystemSettingRepository.SaveChanges(out customMessage1); - null customMessage1 returned"};

                    if (numberOfChanges > 0 && customMessage1.IsErrorCondition == false)
                        customMessage1.MessageDictionary1.Add("SystemSetting_Success", "1");
                    else
                        customMessage1.MessageDictionary2.Add("SystemSetting_Failure", "1");
                }
            }
            customMessage = customMessage1;

            return;
        }

        public virtual SystemSetting Create(string userName, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            SystemSetting dao = null;

            dao = _repository.Create(out customMessage1);

            if (customMessage1 == null)
            {
                customMessage1 = new CustomMessage()
                {
                    MessageDictionary1 = new Dictionary<string, string>(),
                    MessageDictionary2 = new Dictionary<string, string>(),
                    IsErrorCondition = true,
                    Message = "-->> SystemSetting_CrudServices.Create(string userName, out CustomMessage customMessage) - SystemSettingRepository.Create(out customMessage1); - Add(entity, out customMessage1); - null customMessage1 returned"
                };
            }
            else if (dao == null)
            {
                customMessage1.IsErrorCondition = true;
                customMessage1.Message = "SystemSetting_CrudServices.Create() |  SystemSettingRepository.Create() - Null returned";
            }
            else
            {
                dao = SetDefaultPropertyValues(dao, userName);
            }

            customMessage = customMessage1;

            return dao;
        }

        #endregion

        #region Helper Methods

        public bool GetSystemSettingBooleanValue(string systemName)
        {
            bool value = false;

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.BooleanValue;
            }

            return value;
        }

        public decimal GetSystemSettingDecimalValue(string systemName)
        {
            decimal value = 0.0M;

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.DecimalValue;
            }

            return value;
        }

        public int GetSystemSettingIntegerValue(string systemName)
        {
            int value = 0;

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.IntegerValue;
            }

            return value;
        }

        public string GetSystemSettingStringValue(string systemName)
        {
            string value = "";

            if (!string.IsNullOrEmpty(systemName))
            {
                SystemSetting systemSetting = _systemSettingQueries.Get(systemName);

                if (systemSetting != null)
                    value = systemSetting.StringValue;
            }

            return value;
        }

        public virtual bool HasSystemSetting(string systemName)
        {
            bool isFound = _systemSettingQueries.Get(systemName) != null ? true : false;
            return isFound;
        }
        public virtual SystemSetting SetAddPropertyValues(SystemSetting dao, string userName)
        {
            dao.AddedBy = userName;
            dao.AddedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }

        public virtual SystemSetting SetDeletePropertyValues(SystemSetting dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;
            dao.IsDeleted = true;

            return dao;
        }

        public virtual SystemSetting SetUpdatePropertyValues(SystemSetting dao, string userName)
        {
            dao.ChangedBy = userName;
            dao.ChangedDate = _dateTimeAdapter.UtcNow;

            return dao;
        }
        public virtual SystemSetting SetPropertyValues(SystemSetting dao,
                                            int pluginId,
                                            string systemName, string displayName,
                                            string description = "", string stringValue = "",
                                            bool booleanValue = false, decimal decimalValue = 0M,
                                            int integerValue = 0,
                                            bool isActive = true)
        {
            if (dao == null)
                return null;

            dao.PluginId = pluginId;
            dao.SystemName = systemName;
            dao.DisplayName = displayName;
            dao.StringValue = stringValue;
            dao.BooleanValue = booleanValue;
            dao.DecimalValue = decimalValue;
            dao.IntegerValue = integerValue;
            dao.IsActive = isActive;

            return dao;
        }

        public SystemSetting SetDefaultPropertyValues(SystemSetting dao, string userName)
        {
            if (dao == null)
                return null;

            if (HasSystemSetting(SystemSettingConstants.Core_SystemSettingIsActive))
                dao.IsActive = GetSystemSettingBooleanValue(SystemSettingConstants.Core_SystemSettingIsActive);

            dao = SetAddPropertyValues(dao, userName);
            dao = SetUpdatePropertyValues(dao, userName);

            return dao;
        }

        #endregion

    }
}
