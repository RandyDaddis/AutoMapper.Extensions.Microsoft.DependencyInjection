using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial class SqlError_MessageBuilder : ISqlError_MessageBuilder
    {
        #region ctor

        #endregion

        #region Methods

        public virtual string Parse(SqlError ex)
        {
            string message = "";

            if (ex != null)
                   message = " -->>SqlError: " + ex.Message;

            return message;
        }

        #endregion
    }
}
