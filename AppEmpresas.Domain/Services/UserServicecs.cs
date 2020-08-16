using AppEmpresas.Domain.Identity;
using AppEmpresas.Domain.Interfaces.IRepositories;


namespace AppEmpresas.Domain.Services
{
    public class UserServicecs : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServicecs(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Adicionar(User user)
        {
            _userRepository.Add(user);
            return user;
        }

        public void Dispose()
        {
            _userRepository.SaveChangesAsync();
        }
    }
}

    

