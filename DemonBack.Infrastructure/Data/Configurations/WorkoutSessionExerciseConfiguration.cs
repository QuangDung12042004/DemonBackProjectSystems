using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class WorkoutSessionExerciseConfiguration : IEntityTypeConfiguration<WorkoutSessionExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutSessionExercise> b)
    {
        b.ToTable("workout_session_exercises");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.SessionId).HasColumnName("session_id").IsRequired();
        b.Property(x => x.ExerciseId).HasColumnName("exercise_id").IsRequired();
        b.Property(x => x.OrderIndex).HasColumnName("order_index").IsRequired();
        b.Property(x => x.Note).HasColumnName("note");

        b.HasOne(x => x.Session)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.SessionId);

        b.HasOne(x => x.Exercise)
            .WithMany(x => x.WorkoutSessionExercises)
            .HasForeignKey(x => x.ExerciseId);

        b.HasMany(x => x.Sets)
            .WithOne(x => x.SessionExercise)
            .HasForeignKey(x => x.SessionExerciseId);

        b.HasIndex(x => new { x.SessionId, x.OrderIndex });
    }
}