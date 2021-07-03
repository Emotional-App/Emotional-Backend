using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Enums;
using Emotional.Common.Contracts;
using Emotional.Common.Services;
using Emotional.Data.Entities;
using System;
using System.Collections.Generic;

namespace Emotional.Api.Domain.Services
{
    public class EmotionService : IEmotionService
    {
        private IRepository<Emotion> _emotionRepository;

        public EmotionService(IRepository<Emotion> emotionRepository)
        {
            _emotionRepository = emotionRepository;
        }

        public List<Emotion> GetEmotions(Duration duration, string userId)
        {
            var fromDate = GetDateTimeFromDuration(duration);
            var emotions = _emotionRepository.FindMany(x => x.UserId == Guid.Parse(userId) && x.CreatedOn >= fromDate);

            if (emotions == null)
            {
                return new List<Emotion>();
            }

            return emotions;
        }

        public Emotion CreateEmotion(float percentage, string userId)
        {
            try
            {
                var userIdGuid = Guid.Parse(userId);

                ValidateEmotionLimitation(userIdGuid);

                var category = Helper.PercentageToCategory(percentage);

                var emotion = new Emotion
                {
                    Id = Guid.NewGuid(),
                    UserId = userIdGuid,
                    CreatedOn = DateTime.UtcNow,
                    Percentage = percentage,
                    Category = category,
                    CategoryName = category.ToString()
                };

                _emotionRepository.Add(emotion);

                return emotion;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Emotion UpdateEmotion(string emotionId, float percentage, string userId)
        {
            try
            {
                var emotion = _emotionRepository.GetById(Guid.Parse(emotionId));

                if (emotion == null)
                {
                    throw new ApplicationException("The emotion cannot be found.");
                }

                if (emotion.UserId.ToString() != userId)
                {
                    throw new ApplicationException("Unauthorised Request - This emotion does not belong to the user.");
                }

                emotion.Percentage = percentage;
                emotion.Category = Helper.PercentageToCategory(percentage);
                emotion.CategoryName = emotion.Category.ToString();
                _emotionRepository.CommitChanges();

                return emotion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        #region Helpers

        public DateTime GetDateTimeFromDuration(Duration duration)
        {
            switch (duration)
            {
                case Duration.TODAY:
                    return DateTime.Today;

                case Duration.LASTWEEK:
                    return Helper.StartOfWeek();

                default:
                    return Helper.StartOfMonth();
            }
        }

        public void ValidateEmotionLimitation(Guid userIdGuid)
        {
            var todayEmotions = _emotionRepository.FindMany(x => x.UserId == userIdGuid && x.CreatedOn >= DateTime.Today);

            if (todayEmotions.Count == 2)
            {
                throw new ApplicationException("Cannot create more than 2 emotions in a day!");
            }
        }

        #endregion
    }
}
