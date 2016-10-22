using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class StateOrProvinceRepository : RepositoryBase<StateOrProvince>, IStateOrProvinceRepository
    {
        public StateOrProvinceRepository(CoreEFContext context)
            : base(context)
        { }

        // TODO: refactor back to RepositoryBase when EF Core supports create()
        public virtual StateOrProvince Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            StateOrProvince dao = new StateOrProvince();
            customMessage = customMessage1;
            return dao;
        }
    }
}
