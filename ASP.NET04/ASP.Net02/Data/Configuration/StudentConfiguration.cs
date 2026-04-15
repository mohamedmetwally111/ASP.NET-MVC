using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.Net02.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Age)
                   .IsRequired();

            
            builder.HasOne(s => s.Departments)
                   .WithMany(d => d.Students)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

           
            builder.HasMany(s => s.CourseResults)
                   .WithOne(sc => sc.Students)
                   .HasForeignKey(sc => sc.StudentId);
        }
    }
}
