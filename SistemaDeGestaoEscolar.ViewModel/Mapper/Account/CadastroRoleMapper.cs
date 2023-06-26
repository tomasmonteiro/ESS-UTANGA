using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public static class CadastroRoleMapper
    {
        public static List<CadastroRoleViewModel> ToViewModel(this List<IdentityRole<int>> fromList)
        {
            var to = new List<CadastroRoleViewModel>();

            foreach (var item in fromList)
            {
                to.Add(item.ToViewModel());
            }

            return to;
        }

        public static CadastroRoleViewModel ToViewModel(this IdentityRole<int> from)
        {
            var to = new CadastroRoleViewModel { Id = from.Id, Nome = from.Name };
            return to;
        }

        public static IdentityRole<int> ToDomain(this CadastroRoleViewModel from)
        {
            var to = new IdentityRole<int> { Id = from.Id, Name = from.Nome };
            return to;
        }
    }
}