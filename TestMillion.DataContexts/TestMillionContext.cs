using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.Entities.POCOs;

namespace TestMillion.DataContexts
{
   public class TestMillionContext: DbContext
    {

        public TestMillionContext(DbContextOptions<TestMillionContext> options)
           : base(options)
        {

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyTrace> PropertyTrace { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .Property(p => p.Id);   
            modelBuilder.Entity<Owner>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Property>()
                .Property(p => p.Id);
            modelBuilder.Entity<Property>()
               .Property(p => p.CodeInternal)
               .IsRequired();
            modelBuilder.Entity<Property>()
               .Property(p => p.Address)
               .IsRequired();
            modelBuilder.Entity<Property>()
               .Property(p => p.Name)
               .HasMaxLength(250)
               .IsRequired();
            modelBuilder.Entity<Property>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<PropertyImage>()
                .Property(t => t.Id);
            modelBuilder.Entity<PropertyImage>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<PropertyTrace>()
                .Property(t => t.Id);
            modelBuilder.Entity<PropertyTrace>()
                .HasKey(t => t.Id);
        }

    }
}
