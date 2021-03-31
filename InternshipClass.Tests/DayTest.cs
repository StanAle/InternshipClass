using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using InternshipMvc.WebApi;
using InternshippClass.Utilities;
using InternshipMvc.WebApi.Controllers;
using Microsoft.Extensions.Logging.Abstractions;

namespace InternshipClass.Tests
{
    public class DayTest
    {
        [Fact]
        public void CheckEpochConversion()
        {
            // Assume
            long ticks = 1617184800;

            // Act
            DateTime dateTime = DateTimeConverter.ConvertEpochToDayTime(ticks);

            // Assert
            Assert.Equal(2021, dateTime.Year);
            Assert.Equal(3, dateTime.Month);
            Assert.Equal(31, dateTime.Day);
        }
        
        [Fact]
        public void ConvertOutputOfWeatherAPIToWeatherForecast()
        {
            // Assume
            //https://api.openweathermap.org/data/2.5/onecall?lat=45.75&lon=25.3333&exclude=hourly,minutely&appid=432ab032de75c6c0656eb54a71e44a1d
            double latitude = 45.75;
            double longitude = 25.3333;
            var apiKey = "432ab032de75c6c0656eb54a71e44a1d";
            Microsoft.Extensions.Logging.ILogger<WeatherForecastController> nullLogger = new NullLogger<WeatherForecastController>();
            var weatherForecastController = new WeatherForecastController(nullLogger);

            // Act
            var weatherForecasts = weatherForecastController.FetchWeatherForecasts(latitude,longitude,apiKey);
            WeatherForecast weatherForecast = weatherForecasts[1];

            // Assert
            Assert.Equal(285.39, weatherForecast.TemperatureK);
            Assert.Equal(2021, weatherForecast.Date.Year);
            Assert.Equal(4, weatherForecast.Date.Month);
            Assert.Equal(1, weatherForecast.Date.Day);

        }
    }
}
