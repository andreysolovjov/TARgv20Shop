using Microsoft.AspNetCore.Mvc;
using Targv20Shop.Core.Dtos.Weather;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Models.Weather;

namespace Targv20Shop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController(IWeatherForecastServices weatherForecastServices)
            
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity vm = new SearchCity();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
           
            var weatherResponse = _weatherForecastServices.GetForecast(city);

            City vm = new City();


            if (weatherResponse != null)
            {
                vm.Name = weatherResponse.Name;
                vm.Humidity = weatherResponse.Main.Humidity;
                vm.Pressure = weatherResponse.Main.Pressure;
                vm.Temp = weatherResponse.Main.Temp;
                vm.Weather = weatherResponse.Weather[0].Main;
                vm.Wind = weatherResponse.Wind.Speed;
            }

            return View(vm);
        }
    }
}