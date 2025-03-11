using EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF03.ModelConfgurations;

public class CourseInstructorConf : IEntityTypeConfiguration<CourseInstructor>
{
    public void Configure(EntityTypeBuilder<CourseInstructor> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.InstructorId });
        
        builder.HasOne<Course>(x=>x.Course)
            .WithMany(x=>x.CourseInstructors)
            .HasForeignKey(x=>x.CourseId);
        
        builder.HasOne<Instructor>(x=>x.Instructor)
            .WithMany(x=>x.CourseInstructors)
            .HasForeignKey(x=>x.InstructorId);
    }
}