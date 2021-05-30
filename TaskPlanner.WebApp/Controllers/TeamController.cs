using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.WebApp.Models;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.DTO;
using TaskPlanner.WebApp.Filters;
using TaskPlanner.WebApp.Application;

namespace TaskPlanner.WebApp.Controllers
{
    public class TeamController : TaskPlannerController
	{
		public TeamController(ITaskPlannerService _src) : base(_src) { }

		[ActiveItem(MenuItem.Team)]
		public IActionResult MyTeam()
		{
			return View();
		}

		public async Task<IActionResult> MyTeamTable()
		{
			return PartialView("_TeamTable");
		}

		[HttpGet]
		public IActionResult AdditionalMenu() =>
			PartialView("_AdditionalMenu");

		#region crud



		#endregion crud

	}
}