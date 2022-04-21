using Targv20Shop.Core.Dtos.Weather;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        WeatherResponse GetForecast(string city);
    }
}