using Emotional.Data.Entities;
using Emotional.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emotional.Data.Configurations
{
    public class DiaryConfiguration : IEntityTypeConfiguration<Diary>
    {
        public void Configure(EntityTypeBuilder<Diary> builder)
        {
            builder.ToTable("Diaries");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Diaries).HasForeignKey(x => x.UserId);

            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Category).IsRequired().HasDefaultValue(EmotionCategory.PEACEFUL);
        }
    }
}
