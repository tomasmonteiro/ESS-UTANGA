using SistemaDeGestaoEscolar.Data.Domain;
using SistemaDeGestaoEscolar.ViewModel;
using System.Collections.Generic;

namespace SistemaDeGestaoEscolar.WebApp
{
    public static class CadastroUserMapper
    {
        public static List<CadastroUserViewModel> ToViewModel(this List<GestaoUser> fromList)
        {
            var to = new List<CadastroUserViewModel>();

            foreach (var item in fromList)
            {
                to.Add(item.ToViewModel());
            }

            return to;
        }

        public static CadastroUserViewModel ToViewModel(this GestaoUser from)
        {
            var to = new CadastroUserViewModel { Id = from.Id, Nome = from.NomeCompleto, Email = from.Email};
            return to;
        }

        public static GestaoUser ToDomain(this CadastroUserViewModel from)
        {
            var to = new GestaoUser { Id = from.Id, NomeCompleto = from.Nome, Email = from.Email, UserName = from.Email };
            return to;
        }
    }
}