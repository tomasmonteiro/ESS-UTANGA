using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoEscolar.Data.Domain;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public class ApplicationIdentityDbContext : IdentityDbContext<GestaoUser, IdentityRole<int>, int,
     IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GestaoUser>(entity =>
            {
                entity.ToTable("identity_user");
                entity.Property(x => x.NomeCompleto).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Senha).HasMaxLength(100);
                entity.Property(x => x.SenhaConfirmacao).HasMaxLength(100);
            });

            modelBuilder.Entity<IdentityRole<int>>().ToTable(name: "identity_role");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable(name: "identity_user_claim");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable(name: "identity_user_role");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable(name: "identity_user_login");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable(name: "identity_role_claim");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable(name: "identity_user_token");


            modelBuilder.AddSnakeCase(true);
        }

        public ApplicationIdentityDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}

