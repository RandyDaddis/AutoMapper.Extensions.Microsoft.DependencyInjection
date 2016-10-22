using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Repositories.Localization;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Localization
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(CoreEFContext context)
            : base(context)
        {} 

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual Language Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            Language dao = new Language();
            customMessage = customMessage1;
            return dao;
        }
    }
}
