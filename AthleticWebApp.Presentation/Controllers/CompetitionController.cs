using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AthleticWebApp.Presentation.Controllers
{
	public class CompetitionController : Controller
	{
		private readonly ICompetitionService _competitionService;
		private readonly IAthleteService _athleteService;
		public CompetitionController(ICompetitionService competitionService, IAthleteService athleteService)
		{
			_competitionService = competitionService;
			_athleteService = athleteService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var competions = await _competitionService.GetAllCompetitionAsync();

			return View(competions);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var athlete = await _athleteService.GetAllAthleteAsync();

			ViewData["Athlete"] = new SelectList(athlete, "Id", "Name");

			return View();

		}

		[HttpPost]
		public async Task<IActionResult> Add(CompetitionRequest competitionRequest)
		{
			if (ModelState.IsValid)
			{
				await _competitionService.AddCompetitionAsync(competitionRequest);

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]

		public async Task<IActionResult> DeleteCompetition(int id)
		{
			await _competitionService.DeleteCompetitionAsync(id);

			return RedirectToAction("Index", "Competition");
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var competition = await _competitionService.GetCompetitionByIdAsync(id);

			return View(competition);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, CompetitionRequest competitionRequest)
		{
			if (ModelState.IsValid)
			{
				await _competitionService.UpdateCompetitionAsync(id, competitionRequest);

				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
