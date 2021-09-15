using GismeteoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConsumingWebAapiRESTinMVC.Controllers
{
    public class HomeController : Controller
    {
        // Hosted web API REST Service base url
        private const string BASE_URL = "https://localhost:44316/";
        private const string CITIES_API_URL = "api/Cities";
        private static IList<City> _citiesWithWheatherForecasts;

        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync(CITIES_API_URL);
                if (result.IsSuccessStatusCode)
                {
                    // Storing the response details recieved from web api
                    var citiesResponse = result.Content.ReadAsStringAsync().Result;
                    // Deserializing the response recieved from web api and storing into the City list
                    _citiesWithWheatherForecasts = JsonConvert.DeserializeObject<List<City>>(citiesResponse);
                }
                return View(_citiesWithWheatherForecasts);
            }
        }
    }
}
