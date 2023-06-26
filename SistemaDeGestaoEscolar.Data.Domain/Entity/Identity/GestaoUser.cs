using Microsoft.AspNetCore.Identity;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    // TODO: analisar um local melhor para as definições do Identity
    public class GestaoUser : IdentityUser<int>
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }

    }
}