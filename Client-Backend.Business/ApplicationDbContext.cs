using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Client_Backend;

namespace Client_Backend.Business
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /*public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("user");
            modelBuilder.Entity<User>().ToTable("user");

            modelBuilder.Entity<IdentityRole>().ToTable("role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("userrole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogin");
        }
        */
    }
}
