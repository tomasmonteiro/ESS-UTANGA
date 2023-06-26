using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SistemaDeGestaoEscolar.Data.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class GestaoUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<GestaoUser, IdentityRole<int>>
    {
        public GestaoUserClaimsPrincipalFactory(UserManager<GestaoUser> userManager, RoleManager<IdentityRole<int>> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(GestaoUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("NomeCompleto", user.NomeCompleto ?? ""));

            return identity;
        }
    }
}