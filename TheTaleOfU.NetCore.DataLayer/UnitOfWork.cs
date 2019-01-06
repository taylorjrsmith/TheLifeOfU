using System;
using System.Collections.Generic;
using System.Text;

namespace TheTaleOfU.NetCore.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public TheTaleOfUContext Context { get; }

        public UnitOfWork(TheTaleOfUContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
