using Microsoft.AspNetCore.Identity;
using SistemaDeGestaoEscolar.Common;
using System;
using System.Security.Claims;

namespace SistemaDeGestaoEscolar.WebApp
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal principal)
        {
            var ret = 0;

            var claim = principal.FindFirst(new IdentityOptions().ClaimsIdentity.UserIdClaimType);
            if (claim != null)
            {
                _ = int.TryParse(claim.Value, out ret);
            }

            return ret;
        }

        public static bool HasDireitoDeAcesso(this ClaimsPrincipal principal, DireitoDeAcessoEnum direito)
        {
            return principal.HasClaim(direito.ToString(), "true");
        }
    }
}