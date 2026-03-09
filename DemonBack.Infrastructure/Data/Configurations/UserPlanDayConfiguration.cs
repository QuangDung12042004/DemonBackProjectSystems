using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class UserPlanDayConfiguration : IEntityTypeConfiguration<UserPlanDay>
{
    public void Configure(EntityTypeBuilder<UserPlanDay> b)
    {
        b.ToTable("user_plan_days");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserPlanId).HasColumnName("user_plan_id").IsRequired();
        b.Property(x => x.DayOfWeek).HasColumnName("day_of_week").IsRequired();

        b.Property(x => x.NotifyTime)
            .HasColumnName("notify_time")
            .HasColumnType("time")
            .IsRequired();

        b.Property(x => x.Enabled).HasColumnName("enabled").IsRequired();

        b.HasMany(x => x.Exercises)
            .WithOne(x => x.UserPlanDay)
            .HasForeignKey(x => x.UserPlanDayId);

        b.HasMany(x => x.WorkoutSchedules)
            .WithOne(x => x.UserPlanDay)
            .HasForeignKey(x => x.UserPlanDayId);

        b.HasIndex(x => new { x.UserPlanId, x.DayOfWeek }).IsUnique();
    }
}