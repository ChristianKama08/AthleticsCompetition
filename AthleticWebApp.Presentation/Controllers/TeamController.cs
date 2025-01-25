using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AthleticWebApp.Presentation.Controllers
{
	public class TeamController : Controller
	{
		private readonly ITeamService _teamService;
		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var team = await _teamService.GetAllTeamAsync();
			return View(team);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(TeamRequest teamRequest)
		{
			if (ModelState.IsValid)
			{
				await _teamService.AddTeamAsync(teamRequest);

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteTeam(int id)
		{
			await _teamService.DeleteTeamAsync(id);

			return RedirectToAction("Index", "Team");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id )
		{
			var team = await _teamService.GetTeamByIdAsync(id);

			return View(team);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, TeamRequest teamRequest)
		{

			if(ModelState.IsValid)
			{
				await _teamService.UpdateTeamAsync(id, teamRequest);

				return RedirectToAction("Index");
			}

			return View();
		}
	}
}
