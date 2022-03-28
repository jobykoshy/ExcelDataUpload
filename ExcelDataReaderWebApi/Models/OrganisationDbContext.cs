using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace ExcelDataReader.Models
{
    public class OrganisationDbContext : DbContext
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public OrganisationDbContext(DbContextOptions<OrganisationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrganisationConfiguration());

            modelBuilder.Entity<Employee>()
                .Property(c => c.EmployeeId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organisation)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OrganisationNumber);
            modelBuilder.Entity<Employee>()
               .Property(e => e.FirstName)
               .IsRequired(true)
               .HasMaxLength(200);
            modelBuilder.Entity<Employee>()
              .Property(e => e.LastName)
              .IsRequired(true)
              .HasMaxLength(200);


        }
    }

    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> modelBuilder)
        {
            modelBuilder.Property(c => c.OrganisationId)
                .ValueGeneratedOnAdd();
            modelBuilder.Property(c => c.OrganisationName)
                .IsRequired(true)
                .HasMaxLength(200);
            modelBuilder.Property(c => c.OrganisationNumber)
               .IsRequired(true)
               .HasMaxLength(200);
            modelBuilder.Property(c => c.AddressLine1)
               .IsRequired(true)
               .HasMaxLength(200);
            modelBuilder.Property(c => c.AddressLine2)
              .IsRequired(true)
              .HasMaxLength(200);
            modelBuilder.Property(c => c.AddressLine3)
              .IsRequired(false)
              .HasMaxLength(200);
            modelBuilder.Property(c => c.AddressLine4)
              .IsRequired(false)
              .HasMaxLength(200);
            modelBuilder.Property(c => c.Town)
              .IsRequired(true)
              .HasMaxLength(200);
            modelBuilder.Property(c => c.PostCode)
              .IsRequired(true)
              .HasMaxLength(200);
        }
    }
}
