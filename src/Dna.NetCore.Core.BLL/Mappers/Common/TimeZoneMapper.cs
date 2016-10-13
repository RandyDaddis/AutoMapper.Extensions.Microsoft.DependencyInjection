﻿using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using dao = Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    public partial class TimeZoneMapper : ITimeZoneMapper
    {
        #region Methods

        public TimeZoneCmd GetCmdFromDao(dao.TimeZone source)
        {
            TimeZoneCmd value = Mapper.Map<TimeZoneCmd>(source);
            return value;
        }

        public TimeZoneCmd GetCmdFromDto(TimeZoneDto source)
        {
            TimeZoneCmd value = Mapper.Map<TimeZoneCmd>(source);
            return value;
        }

        public dao.TimeZone GetDaoFromCmd(TimeZoneCmd source)
        {
            dao.TimeZone value = Mapper.Map<dao.TimeZone>(source);
            return value;
        }

        public TimeZoneDto GetDtoFromDao(dao.TimeZone source)
        {
            TimeZoneDto value = Mapper.Map<TimeZoneDto>(source);
            return value;
        }

        public IEnumerable<TimeZoneDto> GetDtosFromDaos(IEnumerable<dao.TimeZone> source)
        {
            TimeZoneDto[] value = Mapper.Map<TimeZoneDto[]>(source);
            return value;
        }

        public IEnumerable<TimeZone_Summary> GetSummariesFromDaos(IEnumerable<dao.TimeZone> source)
        {
            TimeZone_Summary[] value = Mapper.Map<TimeZone_Summary[]>(source);
            return value;
        }

        #endregion
    }
}
