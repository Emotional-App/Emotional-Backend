using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Diaries;
using Emotional.Api.Domain.Models.Emotion;
using Emotional.Api.Domain.Models.Enums;
using Emotional.Common.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Emotional.Api.Controllers
{
    [Route("api/diary")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IUserAppContext _userAppContext;

        public DiaryController(IDiaryService diaryService, IUserAppContext userAppContext)
        {
            _diaryService = diaryService;
            _userAppContext = userAppContext;
        }

        [HttpGet("today")]
        public IActionResult GetTodayDiaries()
        {
            var diaries = _diaryService.GetDiaries(Duration.TODAY, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Diaries = diaries });
        }

        [HttpGet("lastweek")]
        public IActionResult GetLastWeekDiaries()
        {
            var diaries = _diaryService.GetDiaries(Duration.LASTWEEK, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Diaries = diaries });
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var diaries = _diaryService.GetDiaries(Duration.ALLTIME, _userAppContext.CurrentUserId);

            return Ok(new { Success = true, Diaries = diaries });
        }

        [HttpPost("create")]
        public IActionResult CreateDiary([FromBody] CreateDiary diary)
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

                var diaryObj = _diaryService.CreateDiary(diary, _userAppContext.CurrentUserId);

                return Ok(new { Success = true, Diary = diaryObj });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateEmotion([FromBody] UpdateDiary diary)
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

                var diaryObj = _diaryService.UpdateDiary(diary, _userAppContext.CurrentUserId);

                return Ok(new { Success = true, Diary = diaryObj });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
