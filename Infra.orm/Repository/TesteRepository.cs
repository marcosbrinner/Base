using Domain.Entity;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.orm.Repository
{
    public class TesteRepository : RepositoryBase<Teste>, ITesteRepository
    {
        private readonly Context _context;

        public TesteRepository(Context context) : base(context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = true;
        }
    }
}
