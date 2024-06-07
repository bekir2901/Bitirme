using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SecondInternshipConfiguration : IEntityTypeConfiguration<SecondInternship>
{
    public void Configure(EntityTypeBuilder<SecondInternship> builder)
    {
        builder.ToTable("SecondInternships").HasKey(si => si.Id);

        builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
        builder.Property(si => si.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(si => si.LecturerId).HasColumnName("LecturerId").IsRequired();
        builder.Property(si => si.Message).HasColumnName("Message").IsRequired();
        builder.Property(si => si.Progress).HasColumnName("Progress").IsRequired();
        builder.Property(si => si.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(si => si.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(si => si.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s => s.Lecturer);
        builder.HasOne(s => s.Student);


        builder.HasQueryFilter(si => !si.DeletedDate.HasValue);
    }
}