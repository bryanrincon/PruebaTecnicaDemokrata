using DemokrataBryan.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemokrataBryan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaModificacion)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Usuario>()
                .Property(u => u.IsDeleted)
                .HasDefaultValue(false)
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Save);
            modelBuilder.Entity<Usuario>()
           .Property(u => u.Sueldo)
           .HasPrecision(18, 2);
        }
    }
}
