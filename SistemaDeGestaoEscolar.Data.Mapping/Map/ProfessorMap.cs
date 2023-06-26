using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;
using System;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class ProfessorMap: BaseEntityMap<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Data_Nascimento).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Hora).HasMaxLength(100).IsRequired();
        }
    }
}
