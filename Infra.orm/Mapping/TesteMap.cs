using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Infra.orm.Mapping
{
    public class TesteMap : EntityTypeConfiguration<Teste>
    {
        public TesteMap()
        {
            ToTable("Teste");

            HasKey(x => x.TesteId)
                .Property(x => x.TesteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
