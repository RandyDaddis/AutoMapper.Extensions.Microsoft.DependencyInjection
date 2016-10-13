using NetCore.Core.Common;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial class SqlErrorCollection_MessageBuilder : ISqlErrorCollection_MessageBuilder
    {
        #region Private Fields

        private readonly ISqlError_MessageBuilder _sqlError_MessageBuilder;
        private CustomMessage _customMessage;
        private SqlErrorCollection _errors;

        #endregion

        #region ctor

        public SqlErrorCollection_MessageBuilder(ISqlError_MessageBuilder sqlError_MessageBuilder)
        {
            _sqlError_MessageBuilder = sqlError_MessageBuilder;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(SqlErrorCollection errors)
        {
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((SqlErrorCollection)_errors == null)
            {
                _customMessage.Message = ".Parse(SqlErrorCollection) - NullReferenceException";
            }
            else
            {
                _errors = errors;

                GetSqlErrors(errors);
            }

            AddMessagePrefix();

            return _customMessage;

        }

        private void GetSqlErrors(SqlErrorCollection errors)
        {
            foreach (SqlError error in errors)
                _customMessage.Message += _sqlError_MessageBuilder.Parse(error);
        }

        private void AddMessagePrefix()
        {
            _customMessage = _customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _customMessage.IsErrorCondition = true;

            _customMessage.Message = " -->>SqlErrorCollection_MessageBuilder: ";
        }

        #endregion
    }
}
