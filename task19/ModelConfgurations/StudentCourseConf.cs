using EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF03.ModelConfgurations;

public class StudentCourseConf : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.StudentId });
        builder.HasOne<Student>(s => s.Student)
            .WithMany(x => x.StudentCourses)
            .HasForeignKey(s => s.StudentId);
        builder.HasOne<Course>(c => c.Course)
            .WithMany(x => x.StudentCourses)
            .HasForeignKey(c => c.CourseId);
    }
}