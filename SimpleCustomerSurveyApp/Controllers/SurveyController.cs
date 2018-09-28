using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.SurveyAggregate;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCustomerSurveyApp.Controllers
{

    [Route("api/[controller]")]
    public class SurveyController : Controller
    {

        private readonly ISurveryRepository _surveyRepository;

        public SurveyController(ISurveryRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        /*private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }*/

        [HttpGet("{surveyId:int}")]
        public async Task<IActionResult> GetSurveyQuestion(int surveyId)
        {
            try
            {
                var survey = await _surveyRepository.GetAsync(surveyId);

                return Ok(survey);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("submit-survey")]
        public async Task<IActionResult> SubmitSurvey([FromBody] SurveyAnswersDTO surveyAnwers)
        {
            try
            {
                //await _surveyService.PostAnswers();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
