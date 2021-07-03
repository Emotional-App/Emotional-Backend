using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Emotion;
using Emotional.Common.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Emotional.Api.Controllers
{
    [Route("api/emotion")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmotionController : Controller
    {
        private readonly IEmotionService _emotionService;
        private readonly IUserAppContext _userAppContext;

        public EmotionController(IEmotionService emotionService, IUserAppContext userAppContext)
        {
            _emotionService = emotionService;
            _userAppContext = userAppContext;
        }

        [HttpGet("today")]
        public IActionResult GetTodayEmotions()
        {
            var emotions = _emotionService.GetEmotions(Duration.TODAY, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpGet("lastweek")]
        public IActionResult GetLastWeekEmotions()
        {
            var emotions = _emotionService.GetEmotions(Duration.LASTWEEK, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpGet("lastmonth")]
        public IActionResult GetLastMonthEmotions()
        {
            var emotions = _emotionService.GetEmotions(Duration.LASTMONTH, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Emotions = emotions });
        }

        [HttpPost("create")]
        public IActionResult CreateEmotion(float percentage)
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

                var emotion = _emotionService.CreateEmotion(percentage, _userAppContext.CurrentUserId);

                return Ok(new { Success = true, Emotion = emotion });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = e.Message });
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

                var updatedEmotion = _emotionService.UpdateEmotion(emotion.EmotionId, emotion.Percentage, _userAppContext.CurrentUserId);

                return Ok(new { Success = true, Emotion = updatedEmotion });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
