using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.No).HasColumnName("No").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
        builder.Property(s => s.Email).HasColumnName("Email").IsRequired();
        builder.Property(s => s.FormalType).HasColumnName("FormalType").IsRequired();
        builder.Property(s => s.EntryYear).HasColumnName("EntryYear").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(s => s.Messages);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}