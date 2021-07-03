using Emotional.Api.Domain.Models.Enums;
using Emotional.Data.Entities;
using System.Collections.Generic;

namespace Emotional.Api.Domain.Contracts
{
    public interface IEmotionService
    {
        List<Emotion> GetEmotions(Duration duration, string userId);
        Emotion CreateEmotion(float percentage, string userId);
        Emotion UpdateEmotion(string emotionId, float percentage, string userId);
    }
}
