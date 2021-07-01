using Emotional.Data.Entities;
using Emotional.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Emotional.Data.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Musics");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MusicUrl).IsRequired();
            builder.Property(x => x.Category).IsRequired();
            builder.Property(e => e.Category).HasConversion(v => v.ToString(),
                v => (EmotionCategory)Enum.Parse(typeof(EmotionCategory), v));
        }
    }
}
