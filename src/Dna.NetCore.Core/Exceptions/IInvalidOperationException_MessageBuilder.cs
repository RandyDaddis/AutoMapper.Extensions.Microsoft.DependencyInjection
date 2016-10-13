using Dna.NetCore.Core.Common;
using System;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface IInvalidOperationException_MessageBuilder
    {
        CustomMessage Parse(InvalidOperationException ex);
    }
}
