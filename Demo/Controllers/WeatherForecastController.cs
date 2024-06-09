using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using EmailService.Interfaces;
using EmailService.Models;
using Entities.Models.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly IEmailSender _emailSender;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherForecastController(IRepositoryManager repository, IEmailSender emailSender) 
        { 
            _repository = repository;
            _emailSender = emailSender;
        }



        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();


        //    List<EmailContent> emailContent = new List<EmailContent>();


        //    foreach (var item in emailContent) {

        //        var message = new Message(new string[] { item.To }, new string[] { }, item.Subject, item.Content);
        //        _emailSender.SendEmail(message);

        //    }




        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {


            return new string[] { "value1", "value2" };
        }

        //private ILoggerManager _logger;

        //public WeatherForecastController(ILoggerManager logger) { _logger = logger; }


        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    _logger.LogInfo("Here is info message from our values controller.");
        //    _logger.LogDebug("Here is debug message from our values controller."); 
        //    _logger.LogWarn("Here is warn message from our values controller.");
        //    _logger.LogError("Here is an error message from our values controller.");

        //    return new string[] { "value1", "value2" };
        //}

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //  }


    }
}
