using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_DnevnikWebApplication.Models
{
    public class EDnevnikContext : DbContext
    {
        public EDnevnikContext(DbContextOptions<EDnevnikContext> options) : base(options)
        {

        }
        public DbSet<Ucenik> Ucenik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ucenik>().ToTable("Ucenik");
        }
    }
}
