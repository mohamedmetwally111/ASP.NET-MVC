using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.Net02.Data.Configuration
{
    public class StuCrsReConfiguration : IEntityTypeConfiguration<StuCrsRe>
    {
        public void Configure(EntityTypeBuilder<StuCrsRe> builder)
        {
            builder.HasKey(sc => new {sc.StudentId,sc.CourseId});


            builder.Property(sc => sc.Grade)
                   .IsRequired();

      
            builder.HasOne(sc => sc.Students)
                   .WithMany(s => s.CourseResults)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(sc => sc.Courses)
                   .WithMany(c => c.StudentResults)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
