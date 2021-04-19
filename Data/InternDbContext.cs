using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshippClass.Data
{
    public class InternDbContext : DbContext
    {
        public InternDbContext(DbContextOptions<InternDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intern>()
                .HasOne(_ => _.Location)
                .WithMany(_ => _.LocalInterns)
                .HasForeignKey("locationId");
                //.IsRequired();
        }
    }
}