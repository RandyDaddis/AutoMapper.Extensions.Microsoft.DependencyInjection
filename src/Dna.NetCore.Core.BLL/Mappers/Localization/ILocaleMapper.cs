using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;

namespace Dna.NetCore.Core.BLL.Mappers.Localization
{
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="AutoMapperConfigurationException"></exception>
	/// <exception cref="AutoMapperMappingException"></exception>
	/// <exception cref="NullReferenceException"></exception>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public interface ILocaleMapper
	{
        LocaleCmd GetCmdFromDao(Locale source);
        Locale GetDaoFromCmd(LocaleCmd source);
        LocaleDto GetDtoFromDao(Locale source);
        IEnumerable<LocaleDto> GetDtosFromDaos(IEnumerable<Locale> source);
        IEnumerable<Locale_Summary> GetSummariesFromDaos(IEnumerable<Locale> source);
    }
}
