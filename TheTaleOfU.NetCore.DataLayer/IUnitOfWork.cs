using System;
using System.Collections.Generic;
using System.Text;

namespace TheTaleOfU.NetCore.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        TheTaleOfUContext Context { get; }
        void Commit();
    }
}
