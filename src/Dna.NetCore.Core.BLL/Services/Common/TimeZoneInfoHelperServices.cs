using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class TimeZoneInfoHelperServices : ITimeZoneInfoHelperServices
    {
        #region Methods

        public TimeZoneInfo GetByDisplayName(string displayName)
        {
            ReadOnlyCollection<TimeZoneInfo> timeZones = GetSystemTimeZones();

            //IEnumerable<TimeZoneInfo> timeZones2 = from timeZone in timeZones where timeZone.DisplayName == displayName select timeZone;
            TimeZoneInfo timeZone = timeZones.SingleOrDefault(a => a.DisplayName == displayName);

            return timeZone;
        }

        public TimeZoneInfo GetByid(string id)
        {
            return FindSystemTimeZoneById(id);
        }

        public string GetIdByDisplayName(string displayName)
        {
            string id = "";
            TimeZoneInfo timeZone = GetByDisplayName(displayName);

            if (timeZone != null)
                id = timeZone.Id;

            return id;
        }

        public TimeZoneInfo GetLocal()
        {
            return TimeZoneInfo.Local;
        }

        public TimeZoneInfo GetUtc()
        {
            return TimeZoneInfo.Utc;
        }

        public bool SupportsDaylightSavingTime(TimeZoneInfo timeZoneInfo)
        {
            return timeZoneInfo.SupportsDaylightSavingTime;
        }

        public TimeZoneInfo FindSystemTimeZoneById(string id)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(id);
        }

        public ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
        {
            return TimeZoneInfo.GetSystemTimeZones();

        }

        public DateTime ConvertTime(DateTime dateTime, TimeZoneInfo destinationTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime, destinationTimeZone);
        }

        //public DateTime ConvertTimeFromUtc(DateTime dateTime, TimeZoneInfo destinationTimeZone)
        //{
        //    return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
        //}

        //public DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfo destinationTimeZone)
        //{
        //    return TimeZoneInfo.ConvertTimeToUtc(dateTime, destinationTimeZone);
        //}

        public TimeSpan GetUtcOffset(DateTime dateTime)
        {
            throw new NotImplementedException("timeZoneInfoHelperServices.GetUtcOffset() >>> not implemented exception");
            // TODO: troubleshoot
            //TimeSpan timeSpan = TimeZoneInfo.GetUtcOffset(dateTime);  // TODO: troubleshoot
            //return timeSpan;
        }
        #endregion
    }
}
