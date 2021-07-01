using Emotional.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Contracts
{
    public interface IEmotionService
    {
        List<Emotion> GetTodayEmotions();
        List<Emotion> GetLastWeekEmotions();
        List<Emotion> GetLastMonthEmotions();
        void CreateEmotion(float percentage);
        void UpdateEmotion(string emotionId, float percentage);
    }
}
