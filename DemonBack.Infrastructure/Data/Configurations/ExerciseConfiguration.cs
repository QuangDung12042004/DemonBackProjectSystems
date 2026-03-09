using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> b)
    {
        b.ToTable("exercises");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();

        b.Property(x => x.MuscleGroup)
            .HasColumnName("muscle_group")
            .HasConversion<int>()
            .IsRequired();

        b.Property(x => x.Description).HasColumnName("description");

        b.Property(x => x.AnimeIconUrl)
            .HasColumnName("anime_icon_url")
            .HasMaxLength(1000);
    }
}