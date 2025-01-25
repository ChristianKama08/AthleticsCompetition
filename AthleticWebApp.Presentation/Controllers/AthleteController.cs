using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AthleticWebApp.Presentation.Controllers
{
    public class AthleteController : Controller
    {
        private readonly IAthleteService _athleteService;
        private readonly ICountryService _countryService;
        private readonly ITeamService _teamService;
        public AthleteController(IAthleteService athleteService, ICountryService countryService, ITeamService teamService)
        {
            _athleteService = athleteService;
            _countryService = countryService;
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var athletes = await _athleteService.GetAllAthleteAsync();

            return View(athletes);
        }

        [HttpGet]
        public async Task<IActionResult> AddAthlete()
        {
            var countries = await _countryService.GetAllCountryAsync();
			ViewData["Countries"] = new SelectList(countries, "Id", "Name");

			var teams = await _teamService.GetAllTeamAsync();
			ViewData["Teams"] = new SelectList(teams, "Id", "Name");

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAthlete(AthleteRequest athleteRequest)
        {
            if (ModelState.IsValid)
            {
                await _athleteService.AddAthleteAsync(athleteRequest);


				return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var athlete = await _athleteService.GetAthleteByIdAsync(id);

			var countries = await _countryService.GetAllCountryAsync();
			ViewData["Countries"] = new SelectList(countries, "Id", "Name");

			var teams = await _teamService.GetAllTeamAsync();
			ViewData["Teams"] = new SelectList(teams, "Id", "Name");

			return View(athlete);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AthleteRequest athleteRequest)
        {
            if (ModelState.IsValid)
            {
                await _athleteService.UpdateAthleteAsync(id, athleteRequest);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAthlete(int id)
        {

            await _athleteService.DeleteAthleteAsync(id);

            return RedirectToAction("Index", "Athlete");
        }
      
    }
}
