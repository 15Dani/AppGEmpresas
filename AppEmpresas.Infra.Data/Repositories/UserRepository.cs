using AppEmpresas.Domain.Entities;
using AppEmpresas.Domain.Identity;
using AppEmpresas.Domain.Interfaces.IRepositories;
using AppEmpresas.Infra.Data.Context;
using System.Threading.Tasks;

namespace AppEmpresas.Infra.Data.Repositories
{
    public class UserRepository  : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
       
       
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


        public async Task<User> GetUserAsyncById(int id)
        {

            return await _context.User.FindAsync(id);

        }

       
    }
}

    

