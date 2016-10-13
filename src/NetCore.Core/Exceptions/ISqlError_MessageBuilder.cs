using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial interface ISqlError_MessageBuilder
    {
        string Parse(SqlError ex);
    }
}
