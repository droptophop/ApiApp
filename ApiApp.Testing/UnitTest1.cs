using System;
using System.Linq;
using ApiApp.Controllers;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ApiApp.Testing
{
    public class UnitTest1
    {
        static private readonly ILogger<WeatherForecastController> _logger;
        WeatherForecastController wfc = new WeatherForecastController(_logger);
        
        [Fact]
        public void GetWeatherForecasts()
        {
            var forecast = wfc.Get();

            Assert.NotEmpty(forecast);
        }
    }
}
