using System;
using System.Collections.Generic;
using System.Linq;

namespace Emotional.Api.Domain.Models.Emotion
{
    public class EmotionResponse : Emotional.Data.Entities.Emotion
    {
        public string CategoryInString { set; get; }
    }
}
