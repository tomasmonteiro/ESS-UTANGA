using System;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    public class Turma: BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Periodo { get; set;}

        public virtual Aluno aluno { get; set; }
        public int IdAluno { get; set; }

        public virtual Professor professor { get; set; }
        public int IdProfessor { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_final { get; set; }
        public DateTime Carga_Horaria { get; set; }

        public virtual Curso Curso { get; set; }
        public int idCurso { get; set; }    

    }
}
