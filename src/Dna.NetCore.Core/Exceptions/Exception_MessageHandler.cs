using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class Exception_MessageHandler : IException_MessageHandler
    {
        #region Private Fields

        private readonly IException_MessageBuilder _exception_MessageBuilder;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public Exception_MessageHandler(IException_MessageBuilder messageBuilder,
                                        ILogger logger
                                        )
        {
            _exception_MessageBuilder = messageBuilder;
            _logger = logger;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Execute(Exception exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((Exception)exception == null)
            {
                customMessage.Message = "Exception_MessageHandler.Execute(exception) - ArgumentNullException";
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

        public virtual CustomMessage ParseMessage(Exception exception, CustomMessage customMessage)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((Exception)exception == null)
            {
                customMessage1.Message = "Exception_MessageHandler.ParseMessage() - ArgumentNullException";
            }
            else
            {
                customMessage1 = _exception_MessageBuilder.Parse(exception);

                if (customMessage1 == null)
                {
                    customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage1.Message = "Exception_MessageHandler.ParseMessage() | _exception_MessageBuilder.Parse(exception) = null returned";
                }
            }

            customMessage1 = AddMessagePrefix(exception, customMessage1);

            return customMessage1;
        }

        private CustomMessage AddMessagePrefix(Exception exception, CustomMessage customMessage)
        {
            CustomMessage customMessage1 = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage1.Message = " -->>Exception - Exception_HResult: "
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
