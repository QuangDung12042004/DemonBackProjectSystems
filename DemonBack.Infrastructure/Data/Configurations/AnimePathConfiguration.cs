using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class AnimePathConfiguration : IEntityTypeConfiguration<AnimePath>
{
    public void Configure(EntityTypeBuilder<AnimePath> b)
    {
        b.ToTable("anime_paths");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.CharacterName)
            .HasColumnName("character_name")
            .HasMaxLength(200)
            .IsRequired();

        b.Property(x => x.Description).HasColumnName("description");

        b.HasMany(x => x.Exercises)
            .WithOne(x => x.Path)
            .HasForeignKey(x => x.PathId);

        b.HasMany(x => x.DerivedUserPlans)
            .WithOne(x => x.SourcePath)
            .HasForeignKey(x => x.SourcePathId);
    }
}