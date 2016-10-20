﻿using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Mappers.Localization;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Localization
{
    public class LocaleMapper : ILocaleMapper
	{
        #region Methods

        public LocaleCmd GetCmdFromDao(Locale source)
		{
			LocaleCmd value = Mapper.Map<LocaleCmd>(source);
			return value;
		}

        public Locale GetDaoFromCmd(LocaleCmd source)
		{
            Locale value = Mapper.Map<Locale>(source);
			return value;
		}

        public LocaleDto GetDtoFromDao(Locale source)
		{
            LocaleDto value = Mapper.Map<LocaleDto>(source);
			return value;
		}

        public IEnumerable<LocaleDto> GetDtosFromDaos(IEnumerable<Locale> source)
		{
            LocaleDto[] value = Mapper.Map<LocaleDto[]>(source);
			return value;
		}

        public IEnumerable<Locale_Summary> GetSummariesFromDaos(IEnumerable<Locale> source)
		{
            Locale_Summary[] value = Mapper.Map<Locale_Summary[]>(source);
			return value;
		}

		#endregion
	}
}
