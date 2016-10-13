using System.Collections.Generic;

namespace Dna.NetCore.Core.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogError(string message);
        void LogError(string message, Dictionary<string, string> args);

    }
}
