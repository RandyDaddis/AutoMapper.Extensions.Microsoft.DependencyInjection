using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class PhoneNumberTypeRepository : RepositoryBase<PhoneNumberType>, IPhoneNumberTypeRepository
    {
        public PhoneNumberTypeRepository(CoreEFContext context)
            : base(context)
        {}

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual PhoneNumberType Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            PhoneNumberType dao = new PhoneNumberType();
            customMessage = customMessage1;
            return dao;
        }
    }
}
