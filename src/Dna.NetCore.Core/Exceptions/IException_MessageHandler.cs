using Dna.NetCore.Core.Common;
using System;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface IException_MessageHandler
    {
        CustomMessage Execute(Exception exception);
        CustomMessage ParseMessage(Exception exception, CustomMessage customMessage);
        void LogException(string message);
    }
}
