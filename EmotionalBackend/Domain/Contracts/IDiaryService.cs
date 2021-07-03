using Emotional.Api.Domain.Models.Diaries;
using Emotional.Api.Domain.Models.Enums;
using Emotional.Data.Entities;
using System.Collections.Generic;

namespace Emotional.Api.Domain.Contracts
{
    public interface IDiaryService
    {
        List<Diary> GetDiaries(Duration duration, string userId);
        Diary CreateDiary(CreateDiary diary, string userId);
        Diary UpdateDiary(UpdateDiary diary, string userId);
    }
}
