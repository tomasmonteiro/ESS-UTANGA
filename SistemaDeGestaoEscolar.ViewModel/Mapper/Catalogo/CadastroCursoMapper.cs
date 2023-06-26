using SistemaDeGestaoEscolar.Data.Domain;
using System.Collections.Generic;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public static class CadastroCursoMapper
    {
        public static List<CadastroCursoViewModel> ToViewModel(this List<Curso> fromList)
        {
            var to = new List<CadastroCursoViewModel>();

            foreach (var item in fromList)
            {
                to.Add(item.ToViewModel());
            }

            return to;
        }

        public static CadastroCursoViewModel ToViewModel(this Curso from)
        {
            var to = new CadastroCursoViewModel { 
                Id = from.Id,
                Nome= from.Nome,
                Requisito= from.Requisito
                
            };
            return to;
        }

        public static Curso ToDomain(this CadastroCursoViewModel from)
        {
            var to = new Curso { 
               Id= from.Id, 
               Nome = from.Nome,
               Requisito= from.Requisito
            };
            return to;
        }
    }
}