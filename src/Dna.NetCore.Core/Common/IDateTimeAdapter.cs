using System;

namespace Dna.NetCore.Core.Common
{
    public interface IDateTimeAdapter
    {
        DateTime UtcNow { get; }
    }
}