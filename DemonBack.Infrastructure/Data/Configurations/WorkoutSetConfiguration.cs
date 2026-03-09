using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class WorkoutSetConfiguration : IEntityTypeConfiguration<WorkoutSet>
{
    public void Configure(EntityTypeBuilder<WorkoutSet> b)
    {
        b.ToTable("workout_sets");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.SessionExerciseId).HasColumnName("session_exercise_id").IsRequired();
        b.Property(x => x.SetNumber).HasColumnName("set_number").IsRequired();

        b.Property(x => x.WeightKg).HasColumnName("weight_kg").HasPrecision(6, 2).IsRequired();
        b.Property(x => x.Reps).HasColumnName("reps").IsRequired();

        b.Property(x => x.Rpe).HasColumnName("rpe").HasPrecision(3, 1);

        b.Property(x => x.IsWarmup).HasColumnName("is_warmup").IsRequired();
        b.Property(x => x.IsPr).HasColumnName("is_pr").IsRequired();

        b.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamptz").IsRequired();

        b.HasIndex(x => new { x.SessionExerciseId, x.SetNumber });
    }
}