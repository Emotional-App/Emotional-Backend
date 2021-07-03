using Emotional.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Services
{
    public class Helper
    {
        private const float EMOTION_GAP = 12.5f;

        public static EmotionCategory PercentageToCategory(float percentage)
        {
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
