using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AthleticWebApp.Presentation.Controllers
{
	public class ResultController : Controller
	{
		private readonly IResultServices _resultServices;
		public ResultController(IResultServices resultServices)
		{
			_resultServices = resultServices;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var result = await _resultServices.GetAllResultAsync();
			
			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Add() 
		{
			return View();

		}

		[HttpPost]
		public async Task<IActionResult>Add(ResultRequest resultRequest) 
		{
			if(ModelState.IsValid)
			{
			    await _resultServices.AddResultAsync(resultRequest);

			   return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult>DeleteResult(int id) 
		{
			await _resultServices.DeleteResultAsync(id);

			return RedirectToAction("Index", "Result");
		}

		
		[HttpGet]
		public async Task<IActionResult>Edit(int id)
		{
			var result = await _resultServices.GetResultByIdAsync(id);

			return View(result);
		
		}

		[HttpPost]
		public async Task<IActionResult>Edit(int id, ResultRequest resultRequest)
		{
			if (ModelState.IsValid)
			{
				 await _resultServices.UpdateResultAsync(id, resultRequest);

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Winners()
		{
			var winners = await _resultServices.WinnersOfEachTournment();

			return View(winners);
		}
	}
}
