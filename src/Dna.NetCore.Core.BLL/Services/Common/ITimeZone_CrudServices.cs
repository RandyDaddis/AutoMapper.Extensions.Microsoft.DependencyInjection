using dao = Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ITimeZone_CrudServices
    {
        void Add(List<dao.TimeZone> list, out CustomMessage customMessage);
        void Add(dao.TimeZone dao, out CustomMessage customMessage);

        TimeZoneCmd Cmd_Create(string userName, out CustomMessage customMessage);
        TimeZoneCmd Cmd_SetPropertyValues(TimeZoneCmd cmd,
                                                            string timeZoneInfoId, string daylightName,
                                                            string displayName, string standardName,
                                                            bool supportsDaylightSavingTime = true,
                                                            bool isActive = true);

        dao.TimeZone Create(string userName, out CustomMessage customMessage);
        dao.TimeZone SetPropertyValues(dao.TimeZone dao,
                                                            string timeZoneInfoId, string daylightName,
                                                            string displayName, string standardName,
                                                            bool supportsDaylightSavingTime = true,
                                                            bool isActive = true);
    }
}