using System;

namespace SistemaDeGestaoEscolar.Data.Domain
{
    public class Matricula: BaseEntity
    {
        public virtual Turma turma { get; set; }
        public int IdTurma { get; set; }
        public virtual Aluno aluno { get; set; }
        public int IdAluno { get; set; }

        public DateTime Data_Matricula { get; set; }
    }
}
