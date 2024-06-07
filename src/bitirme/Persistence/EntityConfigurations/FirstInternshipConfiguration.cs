using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FirstInternshipConfiguration : IEntityTypeConfiguration<FirstInternship>
{
    public void Configure(EntityTypeBuilder<FirstInternship> builder)
    {
        builder.ToTable("FirstInternships").HasKey(fi => fi.Id);

        builder.Property(fi => fi.Id).HasColumnName("Id").IsRequired();
        builder.Property(fi => fi.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(fi => fi.LecturerId).HasColumnName("LecturerId").IsRequired();
        builder.Property(fi => fi.Message).HasColumnName("Message").IsRequired();
        builder.Property(fi => fi.Progress).HasColumnName("Progress").IsRequired();
        builder.Property(fi => fi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fi => fi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fi => fi.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(s => s.Lecturer);
        builder.HasOne(s => s.Student);

        builder.HasQueryFilter(fi => !fi.DeletedDate.HasValue);
    }
}