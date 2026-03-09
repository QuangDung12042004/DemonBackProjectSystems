using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class UserPlanDayExerciseConfiguration : IEntityTypeConfiguration<UserPlanDayExercise>
{
    public void Configure(EntityTypeBuilder<UserPlanDayExercise> b)
    {
        b.ToTable("user_plan_day_exercises");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserPlanDayId).HasColumnName("user_plan_day_id").IsRequired();
        b.Property(x => x.OrderIndex).HasColumnName("order_index").IsRequired();
        b.Property(x => x.ExerciseId).HasColumnName("exercise_id").IsRequired();

        b.Property(x => x.TargetSets).HasColumnName("target_sets");
        b.Property(x => x.TargetReps).HasColumnName("target_reps");

        b.Property(x => x.TargetRpe)
            .HasColumnName("target_rpe")
            .HasPrecision(3, 1);

        b.Property(x => x.RestSeconds).HasColumnName("rest_seconds");

        b.HasOne(x => x.Exercise)
            .WithMany(x => x.UserPlanDayExercises)
            .HasForeignKey(x => x.ExerciseId);

        b.HasIndex(x => new { x.UserPlanDayId, x.OrderIndex });
    }
}