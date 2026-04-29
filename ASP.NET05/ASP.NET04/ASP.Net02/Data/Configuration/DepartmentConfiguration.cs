using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.Net02.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            
            builder.HasKey(d => d.Id);

            
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.MgrName)
                   .HasMaxLength(100);


            builder.HasMany(d => d.Teachers)
                   .WithOne(t => t.Departments)
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

      
            builder.HasMany(d => d.Courses)
                   .WithOne(c => c.Departments)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Students)
                   .WithOne(s => s.Departments)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
