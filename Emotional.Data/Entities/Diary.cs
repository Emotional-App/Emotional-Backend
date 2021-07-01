using System;
using Emotional.Data.Enums;

namespace Emotional.Data.Entities
{
    public class Diary
    {
        public Guid Id { set; get; }
        public string Content{ set; get; }
        public DateTime CreatedOn { set; get; }
        public EmotionCategory Category { set; get; }

        public Guid UserId { set; get; }
        public User User { set; get; }
    }
}
