using BiblioFlow_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.DataAccess
{
    public class BiblioFlowContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BiblioFlow;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            SeedData.SeedAdmin(modelBuilder);
        }
    }
}
