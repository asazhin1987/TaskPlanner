using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.WebApp.Filters;
using TaskPlanner.WebApp.Models;
using static TaskPlanner.WebApp.Application.Enums;

namespace TaskPlanner.WebApp.Controllers
{
	public class HomeController : TaskPlannerController
	{


		public HomeController(ITaskPlannerService _src) : base(_src)
		{

		}

		[ActiveItem(MenuItem.Home)]
		public IActionResult Index()
		{
			return View("Index", UserId.ToString());
		}

		public IActionResult Privacy()
		{
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
