using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InternshippClass.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace InternshippClass.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// Getting weather forecast for 5 days.
        /// </summary>
        /// <returns>Enumerable of weatherForecast objects.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> weatherForcasts = FetchWeatherForecasts();
            return weatherForcasts.GetRange(1, 5);
        }

        [HttpGet("/Forecast")]
        public List<WeatherForecast> FetchWeatherForecasts()
        {
            double latitude = double.Parse(configuration["WeatherForecast:Latitude"], CultureInfo.InvariantCulture);
            double longitude = double.Parse(configuration["WeatherForecast:Longitude"], CultureInfo.InvariantCulture);
            var apiKey = configuration["WeatherForecast:ApiKey"];
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseContentToWeatherForecasts(response.Content);
        }

        [NonAction]
        public List<WeatherForecast> ConvertResponseContentToWeatherForecasts(string content)
        {
            // TODO: Content sometimes is an empty string
            var root = JObject.Parse(content);
            var testToken = root["daily"];
            return (from token in testToken
                    select new WeatherForecast
                    {
                        Date = DateTimeConverter.ConvertEpochToDayTime(long.Parse(token["dt"].ToString())),
                        TemperatureK = double.Parse(token["temp"]["day"].ToString()),
                        Summary = token["weather"][0]["description"].ToString(),
                    }).ToList();
        }
    }
}
