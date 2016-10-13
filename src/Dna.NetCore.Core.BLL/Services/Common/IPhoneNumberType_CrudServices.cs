using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IPhoneNumberType_CrudServices
	{
        void Add(List<PhoneNumberType> list, out CustomMessage customMessage);
        void Add(PhoneNumberType dao, out CustomMessage customMessage);
        PhoneNumberType Create(string userName, out CustomMessage customMessage);
        PhoneNumberType Create(string userName, out CustomMessage customMessage, string systemName, string displayName, bool isActive = true);
        PhoneNumberType SetPropertyValues(PhoneNumberType dao, string systemName, string displayName, bool isActive = true);
    }
}
