using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IAddressType_Queries
	{
        AddressTypeDto Get(int id);
        AddressTypeDto Get(Expression<Func<AddressType, bool>> wherePredicate);

        AddressTypeCmd GetCmd(int id);

        //int GetId(string displayName);

        //IEnumerable<AddressTypeDto> GetList(bool isActive = true);
        IEnumerable<AddressTypeDto> GetList(Expression<Func<AddressType, bool>> wherePredicate);

        IEnumerable<AddressTypeSummary> GetSummaryList(Expression<Func<AddressType, bool>> wherePredicate);
        IPagedList<AddressTypeSummary> GetSummaryPagedList(Expression<Func<AddressType, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);

        bool HasSystemName(string systemName);
        bool HasDisplayName(string displayName);
    }
}
