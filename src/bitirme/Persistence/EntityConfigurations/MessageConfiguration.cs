using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(m => m.LecturerId).HasColumnName("LecturerId").IsRequired();
        builder.Property(m => m.Text).HasColumnName("Text").IsRequired();
        builder.Property(m => m.Title).HasColumnName("Title").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s => s.Lecturer);
        builder.HasOne(s => s.Student);

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}