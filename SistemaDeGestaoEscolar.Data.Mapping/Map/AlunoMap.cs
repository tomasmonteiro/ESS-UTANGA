using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeGestaoEscolar.Data.Domain;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class AlunoMap : BaseEntityMap<Aluno>
    {
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Data_Nascimento).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Numero).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Morada).HasMaxLength(100);
            builder.Property(x => x.Idade).HasMaxLength(100);
            builder.Property(x => x.Contacto).HasMaxLength(100);

            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Id_Disciplina).IsRequired();
            builder.HasOne(x => x.disciplina).WithMany().HasForeignKey(x => x.Id_Disciplina);

        }
    }
}
