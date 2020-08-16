using AppEmpresas.Application.Dto;
using AppEmpresas.Application.IAppServices;
using AppEmpresas.Domain.Entities;
using AppEmpresas.Domain.Identity;
using AppEmpresas.Domain.Interfaces.IRepositories;
using AppEmpresas.Domain.IUoW;
using AppEmpresas.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Application.AppServices
{
    public class UserAppServices : AppServiceBase, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppServices(IUserService userService, IUserRepository userRepository, IUnityOfWork unityOrWork, IMapper mapper) : base(unityOrWork)
        {

            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public UserDto Adicionar(UserDto userDto)
        {
            var dados = _mapper.Map<User>(userDto);
            dados = _userService.Adicionar(dados);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<UserDto>(dados);

        }
        public void Dispose()
        {
            _userRepository.SaveChangesAsync();
        }

        public UserDto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}

    

