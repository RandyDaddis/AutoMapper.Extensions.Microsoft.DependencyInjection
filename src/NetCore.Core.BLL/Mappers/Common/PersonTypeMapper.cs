using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    public partial class PersonTypeMapper : IPersonTypeMapper
    {
        #region Methods

        public PersonTypeCmd GetCmdFromDao(PersonType source)
        {
            PersonTypeCmd value = Mapper.Map<PersonTypeCmd>(source);
            return value;
        }

        public PersonTypeCmd GetCmdFromDto(PersonTypeDto source)
        {
            PersonTypeCmd value = Mapper.Map<PersonTypeCmd>(source);
            return value;
        }

        public PersonType GetDaoFromCmd(PersonTypeCmd source)
        {
            PersonType value = Mapper.Map<PersonType>(source);
            return value;
        }

        public PersonTypeDto GetDtoFromDao(PersonType source)
        {
            PersonTypeDto value = Mapper.Map<PersonTypeDto>(source);
            return value;
        }

        public IEnumerable<PersonTypeDto> GetDtosFromDaos(IEnumerable<PersonType> source)
        {
            PersonTypeDto[] value = Mapper.Map<PersonTypeDto[]>(source);
            return value;
        }

        public IEnumerable<PersonType_Summary> GetSummariesFromDaos(IEnumerable<PersonType> source)
        {
            PersonType_Summary[] value = Mapper.Map<PersonType_Summary[]>(source);
            return value;
        }

        #endregion
    }
}

