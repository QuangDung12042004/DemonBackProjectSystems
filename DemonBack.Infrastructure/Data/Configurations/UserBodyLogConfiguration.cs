using DemonBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemonBack.Infrastructure.Data.Configurations;

public class UserBodyLogConfiguration : IEntityTypeConfiguration<UserBodyLog>
{
    public void Configure(EntityTypeBuilder<UserBodyLog> b)
    {
        b.ToTable("body_logs");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");

        b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();

        b.Property(x => x.LoggedAt).HasColumnName("logged_at").HasColumnType("timestamptz").IsRequired();

        b.Property(x => x.WeightKg).HasColumnName("weight_kg").HasPrecision(6, 2);
        b.Property(x => x.MuscleMassKg).HasColumnName("muscle_mass_kg").HasPrecision(6, 2);
        b.Property(x => x.BodyFatPercent).HasColumnName("body_fat_percent").HasPrecision(5, 2);

        b.Property(x => x.ChestSize).HasColumnName("chest_size").HasPrecision(6, 2);
        b.Property(x => x.WaistSize).HasColumnName("waist_size").HasPrecision(6, 2);
        b.Property(x => x.ArmSize).HasColumnName("arm_size").HasPrecision(6, 2);

        b.Property(x => x.PhotoFrontUrl).HasColumnName("photo_front_url");
        b.Property(x => x.PhotoBackUrl).HasColumnName("photo_back_url");

        b.HasOne(x => x.User)
            .WithMany(x => x.BodyLogs)
            .HasForeignKey(x => x.UserId);

        b.HasIndex(x => new { x.UserId, x.LoggedAt });
    }
}