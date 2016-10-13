using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Repositories.Localization;
using Dna.NetCore.Core.Common;
using NetCore.Core;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Localization
{
    public class LocaleRepository : RepositoryBase<Locale, CoreEFContext>, ILocaleRepository
    {
        public LocaleRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        {
        }
        public virtual Locale Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            // TODO: refactor back to RepositoryBase when EF Core supports create()
            Locale dao = new Locale();
            customMessage = customMessage1;
            return dao;
        }
    }
}
