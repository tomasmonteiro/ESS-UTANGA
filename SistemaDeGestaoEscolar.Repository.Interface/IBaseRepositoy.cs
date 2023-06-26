using System;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.Repository.Interface
{
    public interface IBaseRepositoy
    {
        Task ExecuteInTransactionAsync(Func<Task> code);
        Task SaveChangesAsync();
    }
}
