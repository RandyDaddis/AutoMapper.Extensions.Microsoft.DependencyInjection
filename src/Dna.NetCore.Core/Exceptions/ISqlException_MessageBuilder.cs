using Dna.NetCore.Core.Common;
using System.Data.SqlClient;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface ISqlException_MessageBuilder
    {
        CustomMessage Parse(SqlException ex);
    }
}
