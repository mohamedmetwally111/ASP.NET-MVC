using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.Net02.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Salary)
                   .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Address)
                   .HasMaxLength(200);

            builder.HasOne(t => t.Departments)
                   .WithMany(d => d.Teachers)
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Courses)
                   .WithMany(c=>c.Teachers) 
                   .HasForeignKey(t => t.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
