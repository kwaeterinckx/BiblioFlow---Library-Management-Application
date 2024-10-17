using BiblioFlow_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.DataAccess
{
    internal static class SeedData
    {
        public static void SeedAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    FirstName = "Kévin",
                    LastName = "Waeterinckx",
                    Email = "admin@biblioflow.com",
                    Password = "$2a$11$H5.hbEwp9adKK6hZIpYJHub5CRm27.AljD49xpYhMB4NxOrVVSbi.",
                    Role = "Admin",
                    IsActif = true,
                    CreatedAt = DateTime.Now,
                    CreatedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4")
                }
            );
        }
    }
}
