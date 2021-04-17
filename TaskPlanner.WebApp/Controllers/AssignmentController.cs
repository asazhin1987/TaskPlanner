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
using static TaskPlanner.WebApp.Application.Enums;

namespace TaskPlanner.WebApp.Controllers
{
    public class AssignmentController : TaskPlannerController
	{
		public AssignmentController(ITaskPlannerService _src) : base(_src) { }

		[ActiveItem(MenuItem.MyTasks)]
		public IActionResult MyTasks()
        {
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> TasksPartial()
		{
			return PartialView("_Calendar");
		}

		[HttpGet]
		public IActionResult AdditionalMenu() =>
				PartialView("_AdditionalMenu");

		#region ref


		#endregion ref


		#region crud

		[HttpGet]
		public IActionResult CreateAssignment()
		{
			return PartialView("_MergeAssignment", new AssignmentModel {Id = 0 });
		}


		#endregion 


	}
}