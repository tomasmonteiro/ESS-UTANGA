using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;
using System;

namespace SistemaDeGestaoEscolar.Data.Mapping.Map
{
    public class MatriculaMap: BaseEntityMap<Matricula>
    {
        public override void Configure(EntityTypeBuilder<Matricula> builder)
        {
            base.Configure(builder);   

            builder.Property(x => x.IdAluno).IsRequired();
            builder.HasOne(x => x.aluno).WithMany().HasForeignKey(x => x.IdAluno);


            builder.Property(x => x.IdTurma).IsRequired();
            builder.HasOne(x => x.turma).WithMany().HasForeignKey(x => x.IdTurma);

            builder.Property(x => x.Data_Matricula).HasMaxLength(100).IsRequired();

            
        }
    }
}
