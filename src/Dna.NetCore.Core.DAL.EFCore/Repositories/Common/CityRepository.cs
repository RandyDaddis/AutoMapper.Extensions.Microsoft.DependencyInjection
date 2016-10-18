using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class CityRepository : RepositoryBase<City, CoreEFContext>, ICityRepository
    {
        public CityRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        { }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual City Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            City dao = new City();
            customMessage = customMessage1;
            return dao;
        }
    }
}
