using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class DisciplinaMap : BaseEntityMap<Disciplina>
    {
        public override void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Area).HasMaxLength(100);
            builder.Property(x => x.Programa).HasMaxLength(100);

        }
    }
}
