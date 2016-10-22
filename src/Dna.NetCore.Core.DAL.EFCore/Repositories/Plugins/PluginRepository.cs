using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.Repositories.Plugins;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Plugins
{
    public class PluginRepository : RepositoryBase<Plugin>, IPluginRepository
    {
        public PluginRepository(CoreEFContext context)
            : base(context)
        {
        }
        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual Plugin Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            Plugin dao = new Plugin();
            customMessage = customMessage1;
            return dao;
        }
    }
}
