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
    public partial interface IMimeTypeGroupMapper
	{
        MimeTypeGroupCmd GetCmdFromDao(MimeTypeGroup source);
        MimeTypeGroup GetDaoFromCmd(MimeTypeGroupCmd source);
        MimeTypeGroupDto GetDtoFromDao(MimeTypeGroup source);
        IEnumerable<MimeTypeGroupDto> GetDtosFromDaos(IEnumerable<MimeTypeGroup> source);
        //IEnumerable<MimeTypeGroup_Summary> GetSummariesFromDaos(IEnumerable<MimeTypeGroup> source);
    }
}
