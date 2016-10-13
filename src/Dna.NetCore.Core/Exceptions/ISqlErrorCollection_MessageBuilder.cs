using Dna.NetCore.Core.Common;
using System.Data.SqlClient;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface ISqlErrorCollection_MessageBuilder
    {
        CustomMessage Parse(SqlErrorCollection results);
    }
}
