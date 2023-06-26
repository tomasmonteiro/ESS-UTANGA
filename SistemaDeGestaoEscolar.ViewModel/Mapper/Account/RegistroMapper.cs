using SistemaDeGestaoEscolar.Data.Domain;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public static class RegistroMapper
    {
        public static GestaoUser ToDmain(this RegistroViewModel from)
        {
            // TODO: incluir no BD o campo NOME dos usuários ao registrá-lo
            var to = new GestaoUser { UserName = from.Email, Email = from.Email, NomeCompleto= from.Nome};
            return to;
        }
    }
}