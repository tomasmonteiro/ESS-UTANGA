using Microsoft.AspNetCore.Authorization;
using SistemaDeGestaoEscolar.Common;

namespace SistemaDeGestaoEscolar.WebApp
{
    internal class GestaoAuthorize : AuthorizeAttribute
    {
        public GestaoAuthorize(DireitoDeAcessoEnum direito)
        {
            Policy = direito.ToString();
        }
    }
}