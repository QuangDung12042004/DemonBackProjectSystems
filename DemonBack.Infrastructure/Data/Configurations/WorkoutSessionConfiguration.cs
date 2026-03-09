using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
{
    public void Configure(EntityTypeBuilder<WorkoutSession> b)
    {
        b.ToTable("workout_sessions");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        b.Property(x => x.ScheduleId).HasColumnName("schedule_id");

        b.Property(x => x.StartedAt).HasColumnName("started_at").HasColumnType("timestamptz").IsRequired();
        b.Property(x => x.EndedAt).HasColumnName("ended_at").HasColumnType("timestamptz");

        b.Property(x => x.Note).HasColumnName("note");

        b.Property(x => x.MoodScore).HasColumnName("mood_score");
        b.Property(x => x.FatigueScore).HasColumnName("fatigue_score");

        b.Property(x => x.SleepHours).HasColumnName("sleep_hours").HasPrecision(3, 1);
        b.Property(x => x.SessionRpe).HasColumnName("session_rpe").HasPrecision(3, 1);

        b.HasOne(x => x.User)
            .WithMany(x => x.WorkoutSessions)
            .HasForeignKey(x => x.UserId);

        b.HasOne(x => x.Schedule)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.ScheduleId);

        b.HasMany(x => x.Exercises)
            .WithOne(x => x.Session)
            .HasForeignKey(x => x.SessionId);

        b.HasIndex(x => new { x.UserId, x.StartedAt });
    }
}