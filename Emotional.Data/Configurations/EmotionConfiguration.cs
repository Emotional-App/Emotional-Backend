using Emotional.Data.Entities;
using Emotional.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Emotional.Data.Configurations
{
    class EmotionConfiguration : IEntityTypeConfiguration<Emotion>
    {
        public void Configure(EntityTypeBuilder<Emotion> builder)
        {
            builder.ToTable("Emotions");
                
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Emotions).HasForeignKey(x => x.UserId);

            builder.Property(x => x.Percentage).IsRequired();
            builder.Property(e => e.Category).IsRequired();
            builder.Property(e => e.CategoryName).IsRequired();
        }
    }
}
