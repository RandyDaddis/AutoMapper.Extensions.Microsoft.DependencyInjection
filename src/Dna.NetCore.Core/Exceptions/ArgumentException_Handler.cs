using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;

namespace Dna.NetCore.Core.Exceptions
{
    public static class ArgumentException_Handler
    {
        #region Methods

        public static CustomMessage Handle(this ArgumentException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            customMessage.IsErrorCondition = true;

            customMessage = ParseInnerException(exception, customMessage);

            string message = " -->>ArgumentException_HResult: "
                                + exception.HResult.ToString()
                                + " "
                                + "ParamName" + exception.ParamName
                                + " "
                                + exception.Message ?? ""
                                + " "
                                + customMessage.Message ?? "";

            customMessage.Message = message;

            if (customMessage != null && !string.IsNullOrEmpty(customMessage.Message))
                Log.Write(message);

            return customMessage;
        }

        public static CustomMessage ParseInnerException(this ArgumentException exception, CustomMessage customMessage)
        {
            customMessage = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception.InnerException != null)
            {
                var innerException = exception.InnerException;
                // recursive innerExceptions
                while (innerException != null)
                {
                    customMessage.Message += " -->>InnerException: ";
                    if (!string.IsNullOrEmpty(innerException.Message))
                        customMessage.Message += innerException.Message;

                    // loop if needed to process innerException
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
