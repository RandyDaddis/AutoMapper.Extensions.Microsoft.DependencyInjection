using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IPersonType_CrudServices
	{
        void Add(List<PersonType> list, out CustomMessage customMessage);
        void Add(PersonType dao, out CustomMessage customMessage);
        PersonType Create(string userName, out CustomMessage customMessage);
        PersonType Create(string userName, out CustomMessage customMessage, string systemName, string displayName, bool isActive = true);
        PersonType SetPropertyValues(PersonType dao, string systemName, string displayName, bool isActive = true);
    }
}
