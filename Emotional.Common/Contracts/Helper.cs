using Emotional.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Contracts
{
    public interface Helper
    {
        private const float EMOTION_GAP = 12.5f;

        public static EmotionCategory PercentageToCategory(float percentage)
        {
            return (EmotionCategory)(int)(percentage / EMOTION_GAP);
        }
    }
}
