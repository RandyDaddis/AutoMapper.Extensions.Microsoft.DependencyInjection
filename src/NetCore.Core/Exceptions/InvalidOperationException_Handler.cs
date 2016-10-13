using NetCore.Core.Common;
using NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;

namespace NetCore.Core.Exceptions
{
    public static class InvalidOperationException_Handler
    {
        #region Methods

        public static CustomMessage Handle(this InvalidOperationException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage = ParseInnerException(exception, customMessage);

            string message = " -->>InvalidOperationException_HResult: "
                                + exception.HResult.ToString()
                                + " "
                                + exception.Message ?? ""
                                + " "
                                + customMessage.Message ?? "";

            customMessage.Message = message;

            customMessage.IsErrorCondition = true;

            if (customMessage != null && !string.IsNullOrEmpty(customMessage.Message))
                Log.Write(message);
            
            return customMessage;
        }

        public static CustomMessage ParseInnerException(this InvalidOperationException exception, CustomMessage customMessage)
        {
            customMessage = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception.InnerException != null)
            {
                var innerException = exception.InnerException;
                while (innerException != null)
                {
                    customMessage.Message += " -->>InnerException: ";

                    if (!string.IsNullOrEmpty(innerException.Message))
                        customMessage.Message += innerException.Message;

                    if (innerException.InnerException != null)
                        innerException = innerException.InnerException;
                    else
                        break;
                }
            }

            return customMessage;
        }

        #endregion
    }
}
