using System;
using System.Collections.ObjectModel;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    /// <summary>
    /// wrapper for TimeZone Types
    /// </summary>
    public interface ITimeZoneInfoHelperServices
    {
        /// <summary
        ///     Gets a System.TimeZoneInfo object that represents the local time zone
        /// <returns>
        ///     An object that represents the local time zone
        /// </returns>
        System.TimeZoneInfo GetLocal();
        /// <summary
        ///     Gets a System.TimeZoneInfo object that represents the Coordinated Universal Time
        /// <returns>
        ///     An object that represents the Coordinated Universal Time (UTC) zone
        /// </returns>
        System.TimeZoneInfo GetUtc();
        /// <summary
        ///      Retrieves a System.TimeZoneInfo object from the registry based on its identifier
        /// <param name="id" >
        ///     The time zone identifier, which corresponds to the System.TimeZoneInfo.Id property
        /// </param>
        /// <returns>
        ///     true if the time zone supports daylight saving time; otherwise, false
        /// </returns>
        /// <exception cref="System.OutOfMemoryException">
        ///     The system does not have enough memory to hold information about the time zone
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     The id parameter is null
        /// </exception>
        /// <exception cref="System.TimeZoneNotFoundException">
        ///     The time zone identifier specified by id was not found. This means that a registry
        ///     key whose name matches id does not exist, or that the key exists but does not
        ///     contain any time zone data
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        ///     The process does not have the permissions required to read from the registry
        ///     key that contains the time zone information.
        /// </exception>
        /// <exception cref="System.InvalidTimeZoneException">
        ///      The time zone identifier was found, but the registry data is corrupted
        /// </exception>
        TimeZoneInfo FindSystemTimeZoneById(string id);
        /// <summary
        ///     Returns a sorted collection of all the time zones about which information is available on the local system
        /// </summary>
        /// <returns>
        ///     A read-only collection of System.TimeZoneInfo objects
        /// </returns>
        /// <exception cref="System.OutOfMemoryException">
        ///     The system does not have enough memory to hold information about the time zone
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        ///     The process does not have the permissions required to read from the registry
        ///     key that contains the time zone information.
        /// </exception>
        ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();
        /// <summary
        ///     Returns a sorted collection of all the time zones about which information is available on the local system
        /// </summary>
        /// <returns>
        ///     The date and time in the destination time zone
        /// </returns>
        /// <exception cref="System.ArgumentException">
        ///     The value of the dateTime parameter represents an invalid time
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     The value of the destinationTimeZone parameter is null.
        /// </exception>
        DateTime ConvertTime(DateTime dateTime, TimeZoneInfo destinationTimeZone);
        ///// <summary
        /////     Converts a Coordinated Universal Time (UTC) to the time in a specified time zone
        ///// </summary>
        ///// <returns>
        /////     The date and time in the destination time zone. Its System.DateTime.Kind property
        /////     is System.DateTimeKind.Utc if destinationTimeZone is System.TimeZoneInfo.Utc;
        /////     otherwise, its System.DateTime.Kind property is System.DateTimeKind.Unspecified.
        ///// </returns>
        ///// <exception cref="System.ArgumentException">
        /////     The value of the dateTime parameter represents an invalid time
        ///// </exception>
        ///// <exception cref="System.ArgumentNullException">
        /////     The value of the destinationTimeZone parameter is null.
        ///// </exception>
        //DateTime ConvertTimeFromUtc(DateTime dateTime, TimeZoneInfo destinationTimeZone);
        ///// <summary
        /////     Converts the specified date and time to Coordinated Universal Time (UTC)
        ///// </summary>
        ///// <returns>
        /////     The Coordinated Universal Time (UTC) that corresponds to the dateTime parameter.
        /////     The System.DateTime value's System.DateTime.Kind property is always set to System.DateTimeKind.Utc.
        ///// </returns>
        ///// <exception cref="System.ArgumentException">
        /////     The value of the dateTime parameter represents an invalid time
        ///// </exception>
        ///// <exception cref="System.ArgumentNullException">
        /////     The value of the destinationTimeZone parameter is null.
        ///// </exception>
        //DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfo destinationTimeZone);

        /// <summary
        ///     Calculates the offset or difference between the time in this time zone and Coordinated
        ///     Universal Time (UTC) for a particular date and time.
        /// </summary>
        /// <returns>
        ///     An object that indicates the time difference between the two time zones.
        /// </returns>
        // TODO: Troubleshoot
        TimeSpan GetUtcOffset(DateTime dateTime);  // TODO: troubleshoot
    }
}
