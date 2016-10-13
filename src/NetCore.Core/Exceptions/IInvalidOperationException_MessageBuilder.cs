using NetCore.Core.Common;
using System;

namespace NetCore.Core.Exceptions
{
    public partial interface IInvalidOperationException_MessageBuilder
    {
        CustomMessage Parse(InvalidOperationException ex);
    }
}
