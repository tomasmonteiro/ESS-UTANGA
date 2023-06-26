using SistemaDeGestaoEscolar.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.Repository.Interface
{
    public interface IRepCurso : IBaseRepositoy
    {
       Task<List<Curso>> GetComCursos();
        Task<List<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task<bool> Criar(Curso domain);
        Task<bool> Alterar(Curso domain);
        Task<bool> Excluir(int id);
    }
}
