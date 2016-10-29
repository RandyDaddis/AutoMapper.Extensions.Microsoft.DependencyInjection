using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class MimeTypeMapper : IMimeTypeMapper
	{
        #region Methods

        public MimeTypeCmd GetCmdFromDao(MimeType source)
		{
			MimeTypeCmd value = Mapper.Map<MimeTypeCmd>(source);
			return value;
		}

        public MimeType GetDaoFromCmd(MimeTypeCmd source)
		{
            MimeType value = Mapper.Map<MimeType>(source);
			return value;
		}

        public MimeTypeDto GetDtoFromDao(MimeType source)
		{
            MimeTypeDto value = Mapper.Map<MimeTypeDto>(source);
			return value;
		}

        public IEnumerable<MimeTypeDto> GetDtosFromDaos(IEnumerable<MimeType> source)
		{
            MimeTypeDto[] value = Mapper.Map<MimeTypeDto[]>(source);
			return value;
		}

  //      public IEnumerable<MimeType_Summary> GetSummariesFromDaos(IEnumerable<MimeType> source)
		//{
  //          MimeType_Summary[] value = Mapper.Map<MimeType_Summary[]>(source);
		//	return value;
		//}

		#endregion
	}
}

