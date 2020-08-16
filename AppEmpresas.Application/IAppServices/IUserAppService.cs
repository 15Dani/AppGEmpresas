using AppEmpresas.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Application.IAppServices
{
  public interface IUserAppService
    {
        IEnumerable<UserDto> ObterTodos();

        UserDto ObterPorId(int id);

        UserDto Adicionar(UserDto userDto);
    }
}
