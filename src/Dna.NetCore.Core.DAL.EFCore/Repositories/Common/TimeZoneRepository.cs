using dao = Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using System.Collections.Generic;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories
{
    public class TimeZoneRepository : RepositoryBase<dao.TimeZone, CoreEFContext>, ITimeZoneRepository
    {
        public TimeZoneRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        { }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual dao.TimeZone Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            dao.TimeZone dao = new dao.TimeZone();
            customMessage = customMessage1;
            return dao;
        }
    }
}
