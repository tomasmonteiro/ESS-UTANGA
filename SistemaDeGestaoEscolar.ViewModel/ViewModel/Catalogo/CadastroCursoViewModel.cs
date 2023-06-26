using System;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public class CadastroCursoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Requisito { get; set; }
        public DateTime Carga_Horaria { get; }
        public bool Saving { get; set; }
    }
}
