using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class PathExerciseConfiguration : IEntityTypeConfiguration<PathExercise>
{
    public void Configure(EntityTypeBuilder<PathExercise> b)
    {
        b.ToTable("path_exercises");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.PathId).HasColumnName("path_id").IsRequired();
        b.Property(x => x.DayOfWeek).HasColumnName("day_of_week").IsRequired();
        b.Property(x => x.OrderIndex).HasColumnName("order_index").IsRequired();

        b.Property(x => x.ExerciseId).HasColumnName("exercise_id").IsRequired();

        b.Property(x => x.RecommendedSets).HasColumnName("recommended_sets");
        b.Property(x => x.RecommendedReps).HasColumnName("recommended_reps");
        b.Property(x => x.RestSeconds).HasColumnName("rest_seconds");

        b.HasOne(x => x.Exercise)
            .WithMany(x => x.PathExercises)
            .HasForeignKey(x => x.ExerciseId);

        b.HasOne(x => x.Path)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.PathId);

        b.HasIndex(x => new { x.PathId, x.DayOfWeek, x.OrderIndex });
    }
}