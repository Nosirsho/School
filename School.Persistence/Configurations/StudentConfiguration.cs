using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Core.Model;


namespace School.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(s => s.Parents)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId);

    }
}

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(s => s.Student)
            .WithMany(s => s.Parents)
            .HasForeignKey(s => s.StudentId);

    }
}