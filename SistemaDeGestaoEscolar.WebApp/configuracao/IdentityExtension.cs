using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.Data.Domain;
using SistemaDeGestaoEscolar.Data.Mapping;
using System;

namespace SistemaDeGestaoEscolar.WebApp
{
    public static class IdentityExtension
    {
        private static void SetupIdentityOptions(IdentityOptions options)
        {
            // configuração de Senha
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // configuração de Lockout
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // configuração de Usuário
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;

            // configuração de SignIn
            options.SignIn.RequireConfirmedAccount = false;
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<GestaoUser, IdentityRole<int>>(SetupIdentityOptions)
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddErrorDescriber<ApplicationIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Account/Login";
                options.LogoutPath = $"/Account/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                foreach (var direitoDeAcesso in Enum.GetNames<DireitoDeAcessoEnum>())
                {
                    options.AddPolicy(direitoDeAcesso, policy => policy.RequireClaim(direitoDeAcesso, "true"));
                }
            });
            services.AddScoped<IUserClaimsPrincipalFactory<GestaoUser>, GestaoUserClaimsPrincipalFactory>();
        }
    }
}

