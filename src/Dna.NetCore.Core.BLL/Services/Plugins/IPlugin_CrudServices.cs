using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Plugins
{
    public interface IPlugin_CrudServices
    {
        void Add(PluginCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(PluginDto dto, string userName, out CustomMessage customMessage);
        void Update(PluginCmd cmd, string userName, out CustomMessage customMessage);

        PluginCmd Cmd_Create(string userName, out CustomMessage customMessage);
        PluginCmd Cmd_SetDefaultPropertyValues(PluginCmd cmd, string userName);
    }
}
