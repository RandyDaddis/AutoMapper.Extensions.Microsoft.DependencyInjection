using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.Mappers.Plugins;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Plugins
{
    public class PluginMapper : IPluginMapper
	{
        #region Methods

        public PluginCmd GetCmdFromDao(Plugin source)
		{
			PluginCmd value = Mapper.Map<PluginCmd>(source);
            return value;
		}

        public Plugin GetDaoFromCmd(PluginCmd source)
		{
            Plugin value = Mapper.Map<Plugin>(source);
			return value;
		}

        public PluginDto GetDtoFromDao(Plugin source)
		{
            PluginDto value = Mapper.Map<PluginDto>(source);
			return value;
		}

        public IEnumerable<PluginDto> GetDtosFromDaos(IEnumerable<Plugin> source)
		{
            PluginDto[] value = Mapper.Map<PluginDto[]>(source);
			return value;
		}

        public IEnumerable<PluginSummary> GetSummariesFromDaos(IEnumerable<Plugin> source)
		{
            PluginSummary[] value = Mapper.Map<PluginSummary[]>(source);
			return value;
		}

		#endregion
	}
}
