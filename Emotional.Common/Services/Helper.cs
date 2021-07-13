using Emotional.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Services
{
    public class Helper
    {
        private const float TOTAL_PERCENTAGE = 100f;
        private const int EMOTIONAL_CATEGORY_LENGTH = 8;
        private const float EMOTION_GAP = TOTAL_PERCENTAGE / EMOTIONAL_CATEGORY_LENGTH;

        public static EmotionCategory PercentageToCategory(float percentage)
        {
            if (percentage == TOTAL_PERCENTAGE)
            {
                return EmotionCategory.INLOVE;
            }

            return (EmotionCategory)(int)(percentage / EMOTION_GAP);
        }

        public static DateTime StartOfWeek()
        {
            return DateTime.UtcNow.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);
        }

        public static DateTime StartOfMonth()
        {
            return new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        }
    }
}
