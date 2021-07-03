using Emotional.Api.Domain.Contracts;
using Emotional.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Emotional.Api.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var musicList = _musicService.GetAll();

                return Ok(new { Success = true, Musics = musicList });
            }
            catch (ApplicationException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("category")]
        public IActionResult GetByCategory(EmotionCategory category)
        {
            try
            {
                var musicList = _musicService.GetByCategory(category);

                return Ok(new { Success = true, Musics = musicList });
            }
            catch (ApplicationException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
