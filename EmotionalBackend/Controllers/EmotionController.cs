using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Emotion;
using Emotional.Common.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Emotional.Api.Controllers
{
    [Route("api/emotion")]
    [ApiController]
    public class EmotionController : Controller
    {
        private readonly IEmotionService _emotionService;

        public EmotionController(IEmotionService emotionService)
        {
            _emotionService = emotionService;
        }

        [HttpGet("today")]
        public IActionResult GetTodayEmotions()
        {
            var emotions = _emotionService.GetTodayEmotions();

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpGet("lastweek")]
        public IActionResult GetLastWeekEmotions()
        {
            var emotions = _emotionService.GetLastWeekEmotions();

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpGet("lastmonth")]
        public IActionResult GetLastMonthEmotions()
        {
            var emotions = _emotionService.GetLastMonthEmotions();

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpPost("create")]
        public IActionResult CreateEmotion([FromBody] float percentage)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new
                        {
                            Message = ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                        });
                }

                _emotionService.CreateEmotion(percentage);

                return Ok(new { Success = true });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = "Catch block: Cannot create new item" });
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateEmotion([FromBody] UpdateEmotion emotion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new
                        {
                            Message = ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                        });
                }

                _emotionService.UpdateEmotion(emotion.EmotionId, emotion.Percentage);

                return Ok(new { Success = true });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = "Catch block: Cannot update the item" });
            }
        }
    }
}
