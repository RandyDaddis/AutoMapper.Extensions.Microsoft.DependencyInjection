using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class SqlException_MessageBuilder : ISqlException_MessageBuilder
    {
        #region Private Fields

        private readonly ISqlErrorCollection_MessageBuilder _sqlErrorCollection_MessageBuilder;
        private CustomMessage _customMessage;
        private SqlException _exception;

        #endregion

        #region ctor

        public SqlException_MessageBuilder(ISqlErrorCollection_MessageBuilder sqlError_MessageBuilder)
        {
            _sqlErrorCollection_MessageBuilder = sqlError_MessageBuilder;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(SqlException exception)
        {
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((SqlException)_exception == null)
            {
                _customMessage.Message = ".Parse(exception) - NullReferenceException";
            }
            else
            {
                _exception = exception;

                GetClientConnectionId();
                GetServer();
                GetProcedure();
                GetSqlErrorCollection();

                AddMessagePrefix();
            }

            return _customMessage;
        }

        private void AddMessagePrefix()
        {
            _customMessage = _customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _customMessage.IsErrorCondition = true;

            _customMessage.Message = " -->>SqlException_MessageBuilder: ";
            
            if (!string.IsNullOrEmpty(_exception.Message))
                _customMessage.Message += _exception.Message;
        }

        private void GetClientConnectionId()
        {
            _customMessage.Message = _customMessage.Message
                                        + " ClientConnectionId: "
                                        + _exception.ClientConnectionId.ToString();
        }

        private void GetServer()
        {
            _customMessage.Message = _customMessage.Message
                                        + " | Server: "
                                        + _exception.Server;
        }

        private void GetProcedure()
        {
            _customMessage.Message = _customMessage.Message 
                                        + " | Procedure: " 
                                        + _exception.Procedure;
        }

        private void GetSqlErrorCollection()
        {
            if (_exception.Errors != null && _exception.Errors.Count > 0)
                _customMessage.Message = _customMessage.Message
                                            + " | SQL ErrorCollection: "
                                            + _sqlErrorCollection_MessageBuilder.Parse(_exception.Errors);
        }

        #endregion
    }
}
