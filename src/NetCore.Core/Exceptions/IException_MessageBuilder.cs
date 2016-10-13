using NetCore.Core.Common;
using System;

namespace NetCore.Core.Exceptions
{
    public partial interface IException_MessageBuilder
    {
        CustomMessage Parse(Exception error);
    }
}