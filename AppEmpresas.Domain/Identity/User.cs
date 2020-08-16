using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppEmpresas.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "varchar(150)")]
        public string FullName { get; set; }
        public virtual List<UserRole> Roles { get; set; }
    }
}