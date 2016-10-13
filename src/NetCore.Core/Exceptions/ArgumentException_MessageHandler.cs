using NetCore.Core.Common;
using NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;

namespace NetCore.Core.Exceptions
{
    public partial class ArgumentException_MessageHandler : IArgumentException_MessageHandler
    {
        #region Private Fields

        private readonly IArgumentException_MessageBuilder _argumentException_MessageBuilder;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ArgumentException_MessageHandler(IArgumentException_MessageBuilder messageBuilder,
                                        ILogger logger
                                        )
        {
            _argumentException_MessageBuilder = messageBuilder;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        public virtual CustomMessage Execute(ArgumentException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((ArgumentException)exception == null)
            {
                customMessage.Message = "ArgumentException_MessageHandler.Execute(exception) - NullReferenceException";
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

        public virtual CustomMessage ParseMessage(ArgumentException exception, CustomMessage customMessage = null)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((ArgumentException)exception == null)
            {
                customMessage1.Message = "ArgumentException_MessageHandler.ParseMessage() - ArgumentNullException";
            }
            else
            {
                customMessage1 = _argumentException_MessageBuilder.Parse(exception);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.Message = "ArgumentException_MessageHandler.ParseMessage() | _argumentException_MessageBuilder.Parse(exception) = null returned";
                }
            }

            customMessage1 = AddMessagePrefix(exception, customMessage1);

            return customMessage1;
        }

        private CustomMessage AddMessagePrefix(ArgumentException exception, CustomMessage customMessage = null)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage1.Message = " -->>ArgumentException - Exception_HResult:"
                                        + exception.HResult.ToString()
                                        + " "
                                        + exception.Message ?? ""
                                        + " "
                                        + customMessage1.Message;

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
