using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCustomerSurveyApp.Data;
using SimpleCustomerSurveyApp.DataTransferObjects;

namespace SimpleCustomerSurveyApp.Controllers
{

    [Route("api/[controller]")]
    public class SurveyController : Controller
    {

        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost("create-survey")]
        public async Task<IActionResult> CreateSurvey()
        {
            try
            {
                await _surveyService.CreateSurveyAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{surveyId:int}")]
        public async Task<IActionResult> GetSurveyQuestions(string surveyId)
        {
            try
            {
                var survey = await _surveyService.GetSurveyAsync(surveyId);

                //TODO: Purge answers from survey as they are not needed

                return Ok(survey);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("submit-survey")]
        public async Task<IActionResult> SubmitSurvey([FromBody] SurveyAnswersDTO surveyAnswers)
        {
            try
            {
                await _surveyService.SubmitSurveyAsync(surveyAnswers);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
