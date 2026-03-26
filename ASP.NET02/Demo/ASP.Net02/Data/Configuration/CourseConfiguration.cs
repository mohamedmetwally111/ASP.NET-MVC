using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.Net02.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey((c) => c.Id);

            builder.Property((c) => c.Name)
                .HasMaxLength(60);

            builder.Property((c) => c.Degree)
                .IsRequired();

            builder.Property((c) => c.MinDegree)
                .IsRequired();



            builder.HasOne((c) => c.Departments)
                .WithMany((d) => d.Courses)
                .HasForeignKey((c) => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany((c)=>c.Teachers)
                .WithOne((t)=>t.Courses)
                .HasForeignKey((t)=>t.CourseId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany((c) => c.StudentResults)
                .WithOne((sc) => sc.Courses)
                .HasForeignKey((sc) => sc.CourseId);


        }
    }
}
