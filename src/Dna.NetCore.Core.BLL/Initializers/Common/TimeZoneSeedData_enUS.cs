using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using commonEntities = Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Initializers.Common
{
    public class TimeZoneSeedData_enUS : ISeedData
    {
        #region Private Fields

        private readonly ITimeZone_CrudServices _crudServices;
        private readonly ITimeZoneInfoHelperServices _timeZoneInfoHelperServices;
        private CustomMessage _customMessage;
        private string _userName;

        #endregion

        #region ctor

        public TimeZoneSeedData_enUS(ITimeZone_CrudServices timeZoneService,
                                     ITimeZoneInfoHelperServices timeZoneInfoHelperServices)
        {
            _crudServices = timeZoneService;
            _timeZoneInfoHelperServices = timeZoneInfoHelperServices;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(string userName)
        {
            _userName = userName;

            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            GenerateEntities();

            return _customMessage;
        }

        private void GenerateEntities()
        {
            int addSuccessCount = 0;
            int addFailureCount = 0;

            List<commonEntities.TimeZone> list = GenerateEntityList();

            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _crudServices.Add(list, out customMessage1);

            if (customMessage1 == null)
            {
                customMessage1 = new CustomMessage()
                {
                    MessageDictionary1 = new Dictionary<string, string>(),
                    MessageDictionary2 = new Dictionary<string, string>(),
                    IsErrorCondition = true,
                    Message = "-->> TimeZoneSeedData_enUS.GenerateEntityList() - _crudServices.Add(List<commonEntities.TimeZone> list, out CustomMessage customMessage) - Add(entity, out customMessage1); - null customMessage1 returned"
                };
            }
            else
            {
                if (customMessage1.MessageDictionary1 != null && customMessage1.MessageDictionary1.Count > 0)
                    if (customMessage1.MessageDictionary1.ContainsKey("TimeZone_Success"))
                        addSuccessCount = int.Parse(customMessage1.MessageDictionary1["TimeZone_Success"]);

                if (customMessage1.MessageDictionary2 != null && customMessage1.MessageDictionary2.Count > 0)
                    if (customMessage1.MessageDictionary2.ContainsKey("TimeZone_Failure"))
                        addFailureCount = int.Parse(customMessage1.MessageDictionary2["TimeZone_Failure"]);
            }

            AddResultCountsToCustomMessage("TimeZones", addSuccessCount, addFailureCount);
        }

        private List<commonEntities.TimeZone> GenerateEntityList()
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            List<commonEntities.TimeZone> list = new List<commonEntities.TimeZone>();

            ReadOnlyCollection<TimeZoneInfo> timeZones = _timeZoneInfoHelperServices.GetSystemTimeZones();

            foreach (var item in timeZones)
            {

                commonEntities.TimeZone timeZone = _crudServices.Create(_userName, out customMessage1);
                timeZone = _crudServices.SetPropertyValues(timeZone, item.Id, item.DaylightName, item.DisplayName,
                                                            item.StandardName, item.SupportsDaylightSavingTime);

                list.Add(timeZone);
            }

            return list;
        }

        #endregion

        #region helper methods

        private void AddResultCountsToCustomMessage(string entityName, int addSuccessCount, int addFailureCount)
        {
            _customMessage.MessageDictionary1.Add("Core." + entityName + ".AddSuccessCount", addSuccessCount.ToString());
            _customMessage.MessageDictionary2.Add("Core." + entityName + ".AddFailureCount", addFailureCount.ToString());
        }

        #endregion
    }
}
