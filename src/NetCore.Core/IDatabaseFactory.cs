using System;

namespace NetCore.Core
{
    public interface IDatabaseFactory<T> : IDisposable
    {
        T Get();
    }
}
