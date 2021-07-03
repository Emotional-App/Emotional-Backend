using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Diaries;
using Emotional.Api.Domain.Models.Enums;
using Emotional.Common.Contracts;
using Emotional.Common.Services;
using Emotional.Data.Entities;
using Emotional.Data.Enums;
using System;
using System.Collections.Generic;

namespace Diaryal.Api.Domain.Services
{
    public class MusicService : IMusicService
    {
        private IRepository<Music> _musicRepository;

        public MusicService(IRepository<Music> musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public List<Music> GetAll()
        {
            try 
            {
                return _musicRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurs when geting all musics - " + ex.Message);
            }
        }

        public List<Music> GetByCategory(EmotionCategory category)
        {
            try
            {
                return _musicRepository.FindMany(x => x.Category == category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurs when geting musics by category - " + ex.Message);
            }
        }
    }
}
