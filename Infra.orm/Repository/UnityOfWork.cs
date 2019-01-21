using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.orm.Repository
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly Context _context = new Context();

        public UnityOfWork()
        {
            _context.Configuration.LazyLoadingEnabled = true;

            TesteRepository = new TesteRepository(_context);

        }

        public ITesteRepository TesteRepository { get; set; }
        private bool _disposed;

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private void Clear(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnityOfWork()
        {
            Clear(false);
        }
    }
}
