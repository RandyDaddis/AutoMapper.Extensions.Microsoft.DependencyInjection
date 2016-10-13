using Dna.NetCore.Core.Common;
using System;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface IArgumentException_MessageHandler
    {
        CustomMessage Execute(ArgumentException exception);
        CustomMessage ParseMessage(ArgumentException exception, CustomMessage customMessage);
        void LogException(string message);
    }
}
