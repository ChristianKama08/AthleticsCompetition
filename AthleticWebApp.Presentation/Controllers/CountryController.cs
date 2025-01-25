using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AthleticWebApp.Presentation.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var country = await _countryService.GetAllCountryAsync();

            return View(country);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CountryRequest countryRequest)
        {
            if (ModelState.IsValid)
            {
                await _countryService.AddCountryAsync(countryRequest);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            return View(country);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CountryRequest countryRequest)
        {
            if (ModelState.IsValid)
            {
                await _countryService.UpdateCountryAsync(id, countryRequest);

                return RedirectToAction("Index");
            }
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _countryService.DeleteCountryAsync(id);

            return RedirectToAction("Index", "Country");
        }


    }
}
