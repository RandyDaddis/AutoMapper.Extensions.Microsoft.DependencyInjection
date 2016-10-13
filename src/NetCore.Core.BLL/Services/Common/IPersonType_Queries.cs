using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IPersonType_Queries
	{
        PersonType Get(int id);
        PersonType Get(Expression<Func<PersonType, bool>> wherePredicate);

        IQueryable<PersonType> GetList(Expression<Func<PersonType, bool>> wherePredicate);

        bool HasSystemName(string systemName);
    }
}
