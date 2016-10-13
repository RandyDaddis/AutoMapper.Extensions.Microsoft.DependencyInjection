using NetCore.Core.Common;
using System;

namespace NetCore.Core.Exceptions
{
    public partial interface IInvalidOperationException_MessageHandler
    {
        CustomMessage Execute(InvalidOperationException exception);
        CustomMessage ParseMessage(InvalidOperationException exception, CustomMessage customMessage);
        void LogException(string message);
    }
}
