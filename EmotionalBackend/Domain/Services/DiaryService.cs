using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Diaries;
using Emotional.Api.Domain.Models.Enums;
using Emotional.Common.Contracts;
using Emotional.Common.Services;
using Emotional.Data.Entities;
using System;
using System.Collections.Generic;

namespace Diaryal.Api.Domain.Services
{
    public class DiaryService : IDiaryService
    {
        private IRepository<Diary> _diaryRepository;

        public DiaryService(IRepository<Diary> diaryRepository)
        {
            _diaryRepository = diaryRepository;
        }

        public List<Diary> GetDiaries(Duration duration, string userId)
        {
            var fromDate = GetDateTimeFromDuration(duration);
            var diaries = _diaryRepository.FindMany(x => x.UserId == Guid.Parse(userId) && x.CreatedOn >= fromDate);

            if (diaries == null)
            {
                return new List<Diary>();
            }

            return diaries;
        }

        public Diary CreateDiary(CreateDiary diary, string userId)
        {
            try
            {
                var userIdGuid = Guid.Parse(userId);

                var diaryObj = new Diary
                {
                    Id = Guid.NewGuid(),
                    UserId = userIdGuid,
                    CreatedOn = DateTime.UtcNow,
                    Content = diary.Content,
                    Category = diary.Category,
                    CategoryName = diary.Category?.ToString()
                };

                _diaryRepository.Add(diaryObj);

                return diaryObj;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Diary UpdateDiary(UpdateDiary diary, string userId)
        {
            try
            {
                var diaryObj = _diaryRepository.GetById(Guid.Parse(diary.DiaryId));

                if (diary == null)
                {
                    throw new ApplicationException("The diary cannot be found.");
                }

                if (diaryObj.UserId.ToString() != userId)
                {
                    throw new ApplicationException("Unauthorised Request - This diary does not belong to the user.");
                }

                diaryObj.Content = diary.Content;
                diaryObj.Category = diary.Category;
                diaryObj.CategoryName = diary.Category?.ToString();
                _diaryRepository.CommitChanges();

                return diaryObj;
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

                case Duration.LASTMONTH:
                    return Helper.StartOfMonth();

                default:
                    return new DateTime(0);
            }
        }

        #endregion
    }
}
