using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppEmpresas.Application.Dto
{
   public class UserDto
    {
        [Required(ErrorMessage = "Informe o Nome do Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe o E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe o Nome Completo")]
        public string FullName { get; set; }
    }
}
