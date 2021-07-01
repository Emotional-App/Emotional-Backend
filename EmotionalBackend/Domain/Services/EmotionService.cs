using Emotional.Api.Domain.Contracts;
using Emotional.Common.Contracts;
using Emotional.Common.Security;
using Emotional.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Services
{
    public class EmotionService : IEmotionService
    {
        private IRepository<Emotion> _emotionRepository;
        private readonly IUserAppContext _userAppContext;

        public EmotionService(IRepository<Emotion> emotionRepository,
            IUserAppContext userAppContext)
        {
            _emotionRepository = emotionRepository;
            _userAppContext = userAppContext;
        }

        public List<Emotion> GetLastMonthEmotions()
        {
            int lastMonth = DateTime.Now.AddMonths(-1).Month;
            var emotions = _emotionRepository.FindMany(x => x.CreatedOn.Ticks >= lastMonth);

            if (emotions == null)
            {
                return new List<Emotion>();
            }

            return emotions;
        }

        public List<Emotion> GetLastWeekEmotions()
        {
            int lastWeek = DateTime.Now.AddDays(-7).Day;
            var emotions = _emotionRepository.FindMany(x => x.CreatedOn.Ticks >= lastWeek);

            if (emotions == null)
            {
                return new List<Emotion>();
            }

            return emotions;
        }

        public List<Emotion> GetTodayEmotions()
        {
            int startOfDay = (int)DateTime.Today.Day;
            var emotions = _emotionRepository.FindMany(x => x.CreatedOn.Ticks >= startOfDay);

            if (emotions == null)
            {
                return new List<Emotion>();
            }

            return emotions;
        }

        public void CreateEmotion(float percentage)
        {
            try
            {
                var emotion = new Emotion
                {
                    Id = Guid.NewGuid(),
                    Percentage = percentage,
                    Category = Helper.PercentageToCategory(percentage),
                    CreatedOn = DateTime.UtcNow,
                    UserId = Guid.Parse(_userAppContext.CurrentUserId),
                };

                _emotionRepository.Add(emotion);
            }
            catch(Exception)
            {
                throw new ApplicationException("Cannot create emotion");
            }
        }

        public void UpdateEmotion(string emotionId, float percentage)
        {
            try
            {
                var emotion = _emotionRepository.GetById(Guid.Parse(emotionId));

                if (emotion == null)
                {
                    throw new ApplicationException("The emotion cannot be found.");
                }

                if (emotion.UserId.ToString() != _userAppContext.CurrentUserId)
                {
                    throw new ApplicationException("Unauthorised Request.");
                }

                emotion.Percentage = percentage;
                emotion.Category = Helper.PercentageToCategory(percentage);
                _emotionRepository.CommitChanges();
            }
            catch
            {
                throw new ApplicationException("Cannot update emotion.");
            }
        }
    }
}
