using Emotional.Data.Entities;
using Emotional.Data.Enums;
using System.Collections.Generic;

namespace Emotional.Api.Domain.Contracts
{
    public interface IMusicService
    {
        List<Music> GetAll();
        List<Music> GetByCategory(EmotionCategory category);
    }
}
