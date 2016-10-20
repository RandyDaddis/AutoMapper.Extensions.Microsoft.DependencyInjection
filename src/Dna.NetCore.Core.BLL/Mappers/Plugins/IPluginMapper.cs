using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;

namespace Dna.NetCore.Core.BLL.Mappers.Plugins
{
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="AutoMapperConfigurationException"></exception>
	/// <exception cref="AutoMapperMappingException"></exception>
	/// <exception cref="NullReferenceException"></exception>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public interface IPluginMapper
	{
        /// <summary>
        ///     Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="TSource">Source type to use, regardless of the runtime type</param>
        /// <param name="TDestination">Destination type to create</param>
        /// <returns>Mapped destination object</returns>
        PluginCmd GetCmdFromDao(Plugin source);

        /// <summary>
        ///     Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="TSource">Source type to use, regardless of the runtime type</param>
        /// <param name="TDestination">Destination type to create</param>
        /// <returns>Mapped destination object</returns>
        Plugin GetDaoFromCmd(PluginCmd source);

        /// <summary>
        ///     Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="TSource">Source type to use, regardless of the runtime type</param>
        /// <param name="TDestination">Destination type to create</param>
        /// <returns>Mapped destination object</returns>
        PluginDto GetDtoFromDao(Plugin source);

        /// <summary>
        ///     Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="TSource">Source type to use, regardless of the runtime type</param>
        /// <param name="TDestination">Destination type to create</param>
        /// <returns>Mapped destination object</returns>
        IEnumerable<PluginDto> GetDtosFromDaos(IEnumerable<Plugin> source);

        /// <summary>
        ///     Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="TSource">Source type to use, regardless of the runtime type</param>
        /// <param name="TDestination">Destination type to create</param>
        /// <returns>Mapped destination object</returns>
        IEnumerable<PluginSummary> GetSummariesFromDaos(IEnumerable<Plugin> source);
    }
}
