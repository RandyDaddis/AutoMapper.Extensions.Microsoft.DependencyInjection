using NetCore.Core.Common;
using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial interface ISqlErrorCollection_MessageBuilder
    {
        CustomMessage Parse(SqlErrorCollection results);
    }
}
