using System;
using Emotional.Data.Enums;

namespace Emotional.Data.Entities
{
    public class Music
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string MusicUrl { set; get; }
        public EmotionCategory Category { set; get; }
    }
}
