using AppEmpresas.Domain.Entities;
using AppEmpresas.Domain.Identity;
using AppEmpresas.Infra.Data.EntityConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Infra.Data.Context
{
    public class UserContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>
    >
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(new UserConfiguration().Configure);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(uk => new { uk.UserId, uk.RoleId });

                userRole.HasOne(ur => ur.User)
                    .WithMany(ur => ur.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                userRole.HasOne(ur => ur.Role)
                    .WithMany(ur => ur.Users)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

    
