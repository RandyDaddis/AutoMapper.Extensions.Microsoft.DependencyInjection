using System;

namespace Dna.NetCore.Core
{
    public interface IDatabaseFactory<T> : IDisposable
    {
        T Get();
    }
}
