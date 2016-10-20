using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using dao = Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="AutoMapperConfigurationException"></exception>
    /// <exception cref="AutoMapperMappingException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public partial interface ITimeZoneMapper
    {
        TimeZoneCmd GetCmdFromDao(dao.TimeZone source);
        dao.TimeZone GetDaoFromCmd(TimeZoneCmd source);
        TimeZoneDto GetDtoFromDao(dao.TimeZone source);
        IEnumerable<TimeZoneDto> GetDtosFromDaos(IEnumerable<dao.TimeZone> source);
        IEnumerable<TimeZone_Summary> GetSummariesFromDaos(IEnumerable<dao.TimeZone> source);
    }
}
