using NetCore.Core.BLL.Entities;
using NetCore.Core.BLL.Repositories;
using NetCore.Core.Common;
using System.Collections.Generic;

namespace NetCore.Core.DAL.EFCore.Repositories
{
    public class AddressTypeRepository : RepositoryBase<AddressType, CoreEFContext>, IAddressTypeRepository
    {
        public AddressTypeRepository(IDatabaseFactory<CoreEFContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual AddressType Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            AddressType dao = new AddressType();
            customMessage = customMessage1;
            return dao;
        }
    }
}
