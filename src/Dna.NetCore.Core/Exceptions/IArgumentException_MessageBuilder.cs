using Dna.NetCore.Core.Common;
using System;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface IArgumentException_MessageBuilder
    {
        CustomMessage Parse(ArgumentException ex);
    }
}
