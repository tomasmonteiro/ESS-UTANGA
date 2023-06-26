using System;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    public class Curso: BaseEntity
    {
        public string Nome { get; set; }
        public string Requisito { get;set; }
        public DateTime Carga_Horaria { get;}
    }
}
