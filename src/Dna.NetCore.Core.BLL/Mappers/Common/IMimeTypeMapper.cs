using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="AutoMapperConfigurationException"></exception>
    /// <exception cref="AutoMapperMappingException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public partial interface IMimeTypeMapper
	{
        MimeTypeCmd GetCmdFromDao(MimeType source);
        MimeType GetDaoFromCmd(MimeTypeCmd source);
        MimeTypeDto GetDtoFromDao(MimeType source);
        IEnumerable<MimeTypeDto> GetDtosFromDaos(IEnumerable<MimeType> source);
        //IEnumerable<MimeType_Summary> GetSummariesFromDaos(IEnumerable<MimeType> source);
    }
}
