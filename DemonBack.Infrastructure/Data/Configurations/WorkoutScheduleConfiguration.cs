using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class WorkoutScheduleConfiguration : IEntityTypeConfiguration<WorkoutSchedule>
{
    public void Configure(EntityTypeBuilder<WorkoutSchedule> b)
    {
        b.ToTable("workout_schedules");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        b.Property(x => x.UserPlanDayId).HasColumnName("user_plan_day_id");

        b.Property(x => x.ScheduledDate)
            .HasColumnName("scheduled_date")
            .HasColumnType("date")
            .IsRequired();

        b.Property(x => x.ScheduledTime)
            .HasColumnName("scheduled_time")
            .HasColumnType("time")
            .IsRequired();

        b.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        b.Property(x => x.ParentScheduleId).HasColumnName("parent_schedule_id");
        b.Property(x => x.SuggestionReason).HasColumnName("suggestion_reason").HasMaxLength(500);

        b.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        b.HasOne(x => x.User)
            .WithMany(x => x.WorkoutSchedules)
            .HasForeignKey(x => x.UserId);

        b.HasOne(x => x.ParentSchedule)
            .WithMany(x => x.Reschedules)
            .HasForeignKey(x => x.ParentScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.UserPlanDay)
            .WithMany(x => x.WorkoutSchedules)
            .HasForeignKey(x => x.UserPlanDayId);

        b.HasIndex(x => new { x.UserId, x.ScheduledDate });
        b.HasIndex(x => new { x.UserId, x.Status });
    }
}