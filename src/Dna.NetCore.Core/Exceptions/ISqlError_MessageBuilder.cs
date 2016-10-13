using System.Data.SqlClient;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface ISqlError_MessageBuilder
    {
        string Parse(SqlError ex);
    }
}
