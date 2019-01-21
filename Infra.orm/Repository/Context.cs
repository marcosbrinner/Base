using Domain.Entity;
using Infra.orm.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.orm.Repository
{
    public class Context : DbContext
    {
        public virtual DbSet<Teste> Teste { get; set; }
        public Context()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TesteMap());
        }
    }
}
