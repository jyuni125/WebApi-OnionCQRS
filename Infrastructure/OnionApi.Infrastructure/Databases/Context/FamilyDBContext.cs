using Microsoft.EntityFrameworkCore;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Infrastructure.Databases.Context
{
    public class FamilyDBContext : DbContext
    {
        public FamilyDBContext(DbContextOptions<FamilyDBContext> options) : base(options) { }

        public DbSet<Family> Families { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
