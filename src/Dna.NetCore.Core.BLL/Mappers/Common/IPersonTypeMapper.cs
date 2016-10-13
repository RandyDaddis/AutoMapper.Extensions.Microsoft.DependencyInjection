using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="AutoMapperConfigurationException"></exception>
    /// <exception cref="AutoMapperMappingException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public partial interface IPersonTypeMapper
    {
        PersonTypeCmd GetCmdFromDao(PersonType source);
        PersonTypeCmd GetCmdFromDto(PersonTypeDto source);

        PersonType GetDaoFromCmd(PersonTypeCmd source);

        PersonTypeDto GetDtoFromDao(PersonType source);

        IEnumerable<PersonTypeDto> GetDtosFromDaos(IEnumerable<PersonType> source);

        IEnumerable<PersonType_Summary> GetSummariesFromDaos(IEnumerable<PersonType> source);
    }
}
