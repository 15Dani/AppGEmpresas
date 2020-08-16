using AppEmpresas.Domain.Identity;
using System.Threading.Tasks;

namespace AppEmpresas.Domain.Interfaces.IRepositories
{
    public interface IUserRepository 
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        
    }
}
