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

        public static void SeedLibrary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasData(
                new Library()
                {
                    LibraryId = 1,
                    Name = "Bibliothèque du Savoir Étoilé",
                    Address = "Rue des Lumières 12, 1000 Bruxelles",
                    Phone = "+32 2 123 45 67",
                    Email = "contact@savoiretoile.be",
                    CreatedAt = DateTime.Now,
                    CreatedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                }
            );
        }

        public static void SeedOpeningHours(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OpeningHours>().HasData(
                new OpeningHours()
                {
                    OpeningHourId = 1,
                    DayOfWeek = 1,
                    OpenTime = TimeOnly.Parse("08:00"),
                    CloseTime = TimeOnly.Parse("18:00"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 2,
                    DayOfWeek = 2,
                    OpenTime = TimeOnly.Parse("08:00"),
                    CloseTime = TimeOnly.Parse("18:00"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 3,
                    DayOfWeek = 3,
                    OpenTime = TimeOnly.Parse("12:30"),
                    CloseTime = TimeOnly.Parse("19:00"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 4,
                    DayOfWeek = 4,
                    OpenTime = TimeOnly.Parse("08:00"),
                    CloseTime = TimeOnly.Parse("18:00"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 5,
                    DayOfWeek = 5,
                    OpenTime = TimeOnly.Parse("08:00"),
                    CloseTime = TimeOnly.Parse("20:00"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 6,
                    DayOfWeek = 6,
                    OpenTime = TimeOnly.Parse("09:00"),
                    CloseTime = TimeOnly.Parse("12:30"),
                    IsClosed = false,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                },
                new OpeningHours()
                {
                    OpeningHourId = 7,
                    DayOfWeek = 7,
                    OpenTime = null,
                    CloseTime = null,
                    IsClosed = true,
                    LastModifiedAt = DateTime.Now,
                    LastModifiedByUserId = Guid.Parse("24C23CBE-1B1E-46E1-8DAC-91C55706ECA4"),
                    LibraryId = 1
                }
            );
        }
    }
}
