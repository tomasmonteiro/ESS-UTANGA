using System;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    public class Professor: BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set;}
        public string Email { get; set; }   
        public DateTime Hora { get; set;}
    }
}
