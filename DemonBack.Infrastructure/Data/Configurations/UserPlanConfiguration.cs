using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class UserPlanConfiguration : IEntityTypeConfiguration<UserPlan>
{
    public void Configure(EntityTypeBuilder<UserPlan> b)
    {
        b.ToTable("user_plans");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        b.Property(x => x.SourcePathId).HasColumnName("source_path_id");

        b.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
        b.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();

        b.Property(x => x.StartedAt)
            .HasColumnName("started_at")
            .HasColumnType("date")
            .IsRequired();

        b.HasOne(x => x.User)
            .WithMany(x => x.Plans)
            .HasForeignKey(x => x.UserId);

        b.HasOne(x => x.SourcePath)
            .WithMany(x => x.DerivedUserPlans)
            .HasForeignKey(x => x.SourcePathId);

        b.HasMany(x => x.Days)
            .WithOne(x => x.UserPlan)
            .HasForeignKey(x => x.UserPlanId);

        b.HasIndex(x => new { x.UserId, x.IsActive });
    }
}