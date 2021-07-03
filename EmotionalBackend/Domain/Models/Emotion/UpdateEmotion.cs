using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Models.Emotion
{
    public class UpdateEmotion
    {
        public string EmotionId { set; get; }
        public float Percentage { set; get; }
    }
}
