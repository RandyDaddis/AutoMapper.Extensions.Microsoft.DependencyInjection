using System;

namespace Dna.NetCore.Core.Common
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
