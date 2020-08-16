using AppEmpresas.Domain.Entities;
using AppEmpresas.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Domain.Services
{
    public interface IUserService 
    {
        User Adicionar(User user);
       
    }
}
