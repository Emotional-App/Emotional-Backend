using Emotional.Data.Entities;
using Emotional.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Data.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static void Seed(this ModelBuilder modelBuider)
        {
            var userId = Guid.NewGuid();

            var hasher = new PasswordHasher<User>();
            modelBuider.Entity<User>().HasData(new User
            {
                Id = userId,
                Email = "Emotional@gmail.com",
                Name = "Emotional",
                HashPassword = hasher.HashPassword(null, "test123")
            });

            modelBuider.Entity<Emotion>().HasData(new Emotion
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Category = EmotionCategory.PEACEFUL,
                CategoryName = EmotionCategory.PEACEFUL.ToString(),
                Percentage = 70,
                CreatedOn = DateTime.UtcNow
            });

            modelBuider.Entity<Diary>().HasData(new Diary
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Content = "Today is a good day.",
                CreatedOn = DateTime.UtcNow
            });

            modelBuider.Entity<Music>().HasData(new Music
            {
                Id = Guid.NewGuid(),
                Category = EmotionCategory.PEACEFUL,
                CategoryName = EmotionCategory.PEACEFUL.ToString(),
                MusicUrl = "https://freesound.org/data/previews/554/554415_2975501-lq.mp3",
                Name = "Peaceful-sound-001"
            });
        }
    }
}
