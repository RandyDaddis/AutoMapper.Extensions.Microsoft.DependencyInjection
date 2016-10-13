using NetCore.Core.Common;
using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial interface ISqlException_MessageHandler
    {
        CustomMessage Execute(SqlException exception);
        CustomMessage ParseMessage(SqlException exception, CustomMessage customMessage);
        void LogException(string message);
    }
}
