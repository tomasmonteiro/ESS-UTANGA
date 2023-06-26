using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class CursoMap:BaseEntityMap<Curso>
    {
        public override void Configure(EntityTypeBuilder<Curso> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Requisito).HasMaxLength(100);
            builder.Property(x => x.Carga_Horaria).HasMaxLength(100);

            

        }
    }
}
