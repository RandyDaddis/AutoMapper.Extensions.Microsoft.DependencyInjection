using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class MimeTypeGroupMapper : IMimeTypeGroupMapper
	{
        #region Methods

        public MimeTypeGroupCmd GetCmdFromDao(MimeTypeGroup source)
		{
			MimeTypeGroupCmd value = Mapper.Map<MimeTypeGroupCmd>(source);
			return value;
		}

        public MimeTypeGroupCmd GetCmdFromDto(MimeTypeGroupDto source)
        {
            MimeTypeGroupCmd value = Mapper.Map<MimeTypeGroupCmd>(source);
            return value;
        }

        public MimeTypeGroup GetDaoFromCmd(MimeTypeGroupCmd source)
		{
            MimeTypeGroup value = Mapper.Map<MimeTypeGroup>(source);
			return value;
		}

        public MimeTypeGroupDto GetDtoFromDao(MimeTypeGroup source)
		{
            MimeTypeGroupDto value = Mapper.Map<MimeTypeGroupDto>(source);
			return value;
		}

        public IEnumerable<MimeTypeGroupDto> GetDtosFromDaos(IEnumerable<MimeTypeGroup> source)
		{
            MimeTypeGroupDto[] value = Mapper.Map<MimeTypeGroupDto[]>(source);
			return value;
		}

  //      public IEnumerable<MimeTypeGroup_Summary> GetSummariesFromDaos(IEnumerable<MimeTypeGroup> source)
		//{
  //          MimeTypeGroup_Summary[] value = Mapper.Map<MimeTypeGroup_Summary[]>(source);
		//	return value;
		//}

		#endregion
	}
}

