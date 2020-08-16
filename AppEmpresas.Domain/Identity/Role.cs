using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual List<UserRole> Users { get; set; }
    }
}