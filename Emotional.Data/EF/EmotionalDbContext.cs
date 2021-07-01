using Microsoft.EntityFrameworkCore;
using Emotional.Data.Entities;
using Emotional.Data.Configurations;
using Emotional.Data.Extensions;

namespace Emotional.Data.EF
{
    public class EmotionalDbContext : DbContext
    {
        public EmotionalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmotionConfiguration());
            builder.ApplyConfiguration(new DiaryConfiguration());
            builder.ApplyConfiguration(new MusicConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            builder.Seed();
        }

        public DbSet<Emotion> Emotions { set; get; }
        public DbSet<Diary> Diaries { set; get; }
        public DbSet<Music> Musics { set; get; }
        public DbSet<User> Users { set; get; }
    }

}
