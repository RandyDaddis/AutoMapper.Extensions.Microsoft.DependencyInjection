using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class InvalidOperationException_MessageHandler : IInvalidOperationException_MessageHandler
    {
        #region Private Fields

        private readonly IInvalidOperationException_MessageBuilder _invalidOperationException_MessageBuilder;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public InvalidOperationException_MessageHandler(IInvalidOperationException_MessageBuilder messageBuilder,
                                        ILogger logger
                                        )
        {
            _invalidOperationException_MessageBuilder = messageBuilder;
            _logger = logger;
        }

        #endregion

        #region PUblic Methods

        public virtual CustomMessage Execute(InvalidOperationException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception == null)
            {
                customMessage.Message = "InvalidOperationException_MessageHandler.Execute(exception) - ArgumentNullException";
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

        public virtual CustomMessage ParseMessage(InvalidOperationException exception, CustomMessage customMessage = null)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception == null)
            {
                customMessage1.Message = "InvalidOperationException_MessageHandler.ParseMessage() - ArgumentNullException";
            }
            else
            {
                customMessage1 = _invalidOperationException_MessageBuilder.Parse(exception);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.Message = "InvalidOperationException_MessageHandler.ParseMessage() | _invalidOperationException_MessageBuilder.Parse(exception) = null returned";
                }
            }

            customMessage1 = AddMessagePrefix(exception, customMessage1);

            return customMessage1;
        }

        private CustomMessage AddMessagePrefix(InvalidOperationException exception, CustomMessage customMessage = null)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage1.Message = " -->>InvalidOperationException - Exception_HResult:"
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
