using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;
using System;

namespace SistemaDeGestaoEscolar.Data.Mapping.Map
{
    public class TurmaMap: BaseEntityMap<Turma>
    {
        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property (x => x.Periodo).HasMaxLength(100).IsRequired();    

            builder.Property(x => x.IdAluno).IsRequired();
            builder.HasOne(x => x.aluno).WithMany().HasForeignKey(x => x.IdAluno);


            builder.Property(x => x.IdProfessor).IsRequired();
            builder.HasOne(x => x.professor).WithMany().HasForeignKey(x => x.IdProfessor);

            builder.Property(x => x.idCurso).IsRequired();
            builder.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.idCurso);

            builder.Property(x => x.Data_Inicio).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Data_final).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Carga_Horaria).HasMaxLength(100);
        }
    }
}
