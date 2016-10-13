using NetCore.Core.Common;
using System;

namespace NetCore.Core.Exceptions
{
    public partial interface IArgumentException_MessageBuilder
    {
        CustomMessage Parse(ArgumentException ex);
    }
}
