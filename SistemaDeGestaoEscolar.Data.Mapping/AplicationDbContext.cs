
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoEscolar.Data.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityMap<>).Assembly);

            modelBuilder.AddSnakeCase(false);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Professor> professores { get; set;}
        public DbSet<Turma> turmas { get; set;}
        public DbSet<Disciplina> disciplinas { get; set;}
        public DbSet<Curso> cursos { get; set;}  
        public DbSet<Matricula> matriculas { get; set;}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => (e.Entity is BaseEntity) && (e.State == EntityState.Added));

            // preenche o campo CreatedAt com a data+hora quando a entidade está sendo incluída
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    var entity = (BaseEntity)entityEntry.Entity;
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
