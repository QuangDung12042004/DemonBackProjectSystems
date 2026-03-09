using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("users");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id"); // <-- quan trọng để không ra "Id"

        b.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();

        b.Property(x => x.Email).HasColumnName("email").HasMaxLength(320);
        b.HasIndex(x => x.Email).IsUnique();

        b.Property(x => x.CurrentWeightKg)
            .HasColumnName("current_weight_kg")
            .HasPrecision(6, 2);

        b.Property(x => x.Goal).HasColumnName("goal").HasMaxLength(200);

        b.Property(x => x.PreferredUnit)
            .HasColumnName("preferred_unit")
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();

        b.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        // Extra fields -> snake_case
        b.Property(x => x.AvatarUrl).HasColumnName("avatar_url");
        b.Property(x => x.CurrentLevel).HasColumnName("current_level").IsRequired();
        b.Property(x => x.CurrentExp).HasColumnName("current_exp").IsRequired();
        b.Property(x => x.RankTitle).HasColumnName("rank_title").IsRequired();
        b.Property(x => x.StreakDays).HasColumnName("streak_days").IsRequired();

        // Relations
        b.HasMany(x => x.Plans)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        b.HasMany(x => x.WorkoutSchedules)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        b.HasMany(x => x.WorkoutSessions)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        b.HasMany(x => x.BodyLogs)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}