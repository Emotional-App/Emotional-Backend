using Emotional.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Models.Diaries
{
    public class CreateDiary
    {
        public string Content { set; get; }
        public EmotionCategory? Category { set; get; }
    }

    public class UpdateDiary : CreateDiary
    {
        public string DiaryId { set; get; }
    }
}
