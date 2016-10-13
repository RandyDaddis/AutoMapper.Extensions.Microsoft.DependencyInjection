using NetCore.Core.Common;
using NetCore.Core.Infrastructure.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCore.Core.Exceptions
{
    public partial class SqlException_MessageHandler : ISqlException_MessageHandler
    {
        #region Private Fields

        private readonly ISqlException_MessageBuilder _sqlException_MessageBuilder;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public SqlException_MessageHandler(ISqlException_MessageBuilder messageBuilder,
                                        ILogger logger)
        {
            _sqlException_MessageBuilder = messageBuilder;
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// parse the exception message stack and log the exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>CustomMessage</returns>
        public virtual CustomMessage Execute(SqlException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((SqlException)exception == null)
            {
                customMessage.Message = "SqlException_MessageHandler.Execute(exception) - ArgumentNullException";
                customMessage = AddMessagePrefix(exception, customMessage);
            }
            else
            {
                customMessage = ParseMessage(exception, customMessage);
            }

            if (customMessage != null)
                LogException(customMessage.Message);

            return customMessage;
        }

        /// <summary>
        /// parse the exception message stack - but - does not log the exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="customMessage"></param>
        /// <returns>CustomMessage</returns>
        public virtual CustomMessage ParseMessage(SqlException exception, CustomMessage customMessage)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((SqlException)exception == null)
            {
                customMessage1.Message = "SqlException_MessageHandler.ParseMessage() - ArgumentNullException";
            }
            else
            {
                customMessage1 = _sqlException_MessageBuilder.Parse(exception);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.Message = "SqlException_MessageHandler.ParseMessage() | _sqlException_MessageBuilder.Parse(exception) = null returned";
                }
            }

            customMessage1 = AddMessagePrefix(exception, customMessage1);

            return customMessage1;
        }

        private CustomMessage AddMessagePrefix(SqlException exception, CustomMessage customMessage)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage1.Message = " -->>SqlException - Exception_HResult:" 
                                        + exception.HResult.ToString()
                                        + " "
                                        + exception.Message ?? ""
                                        + " "
                                        + customMessage1.Message ?? "";

            customMessage1.IsErrorCondition = true;

            return customMessage1;
        }

        public virtual void LogException(string message)
        {
            if (!string.IsNullOrEmpty(message))
                _logger.LogError(message);
        }

        #endregion
    }
}
