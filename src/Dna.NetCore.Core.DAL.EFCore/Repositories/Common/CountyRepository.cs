using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class CountyRepository : RepositoryBase<County, CoreEFContext>, ICountyRepository
    {
        public CountyRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        { }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual County Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            County dao = new County();
            customMessage = customMessage1;
            return dao;
        }
    }
}
