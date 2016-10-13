using Dna.NetCore.Core.Common;
using System;

namespace Dna.NetCore.Core.Exceptions
{
    public partial interface IException_MessageBuilder
    {
        CustomMessage Parse(Exception error);
    }
}