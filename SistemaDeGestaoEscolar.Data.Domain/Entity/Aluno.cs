using SistemaDeGestaoEscolar.Data.Domain;
using System;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    public class Aluno: BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set;}
        public int Numero { get; set; }
        public string Morada { get;set; }
        public int Idade { get;set; }
        public int Contacto { get; set;}
        public string Email { get;set; }
        public virtual Disciplina disciplina { get; set; }
        public int Id_Disciplina { get; set; }
    }
}
