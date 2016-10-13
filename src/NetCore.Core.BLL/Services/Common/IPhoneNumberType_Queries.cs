using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IPhoneNumberType_Queries
	{
        PhoneNumberType Get(int id);
        PhoneNumberType Get(Expression<Func<PhoneNumberType, bool>> wherePredicate);

        IQueryable<PhoneNumberType> GetList(Expression<Func<PhoneNumberType, bool>> wherePredicate);

        bool HasSystemName(string systemName);
    }
}
