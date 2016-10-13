using System;

namespace NetCore.Core.Common
{
    public interface IDateTimeAdapter
    {
        DateTime UtcNow { get; }
    }
}