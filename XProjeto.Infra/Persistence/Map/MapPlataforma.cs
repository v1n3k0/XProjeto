using System.Data.Entity.ModelConfiguration;
using XProjeto.Domain.Entities;

namespace XProjeto.Infra.Persistence.Map
{
    public class MapPlataforma : EntityTypeConfiguration<Plataforma>
    {
        public MapPlataforma()
        {
            ToTable("Plataforma");

            Property(p => p.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
