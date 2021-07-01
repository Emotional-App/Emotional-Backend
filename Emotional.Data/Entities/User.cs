using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Data.Entities
{
    public class User
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string HashPassword { set; get; }
        public string AvatarUrl { set; get; }

        public List<Emotion> Emotions { set; get; }
        public List<Diary> Diaries{ set; get; }
    }
}
