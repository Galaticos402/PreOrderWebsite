using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer;
using System.Linq.Expressions;
using System.Collections.Generic;
using BusinessLayer.Services.AccountService;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AddressRepository addressRepository;
        private readonly IAccountService _accountService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AddressRepository address, IAccountService accountService)
        {
            addressRepository = address;
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("/test")]
        public async Task<ObjectResult> GetAccountById(int accountId)
        {
            var res = await _accountService.GetAccountById(accountId);
            return res;
        }
    }
}