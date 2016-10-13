using NetCore.Core.Common;
using System.Data.Common;

namespace NetCore.Core.Exceptions
{
    public partial interface IDbException_MessageBuilder
    {
        CustomMessage Parse(DbException ex);
    }
}
