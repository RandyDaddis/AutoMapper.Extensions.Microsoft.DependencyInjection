using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class MimeTypeGroupRepository : RepositoryBase<MimeTypeGroup, CoreEFContext>, IMimeTypeGroupRepository
    {
        public MimeTypeGroupRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        { }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual MimeTypeGroup Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            MimeTypeGroup dao = new MimeTypeGroup();
            customMessage = customMessage1;
            return dao;
        }
    }
}
