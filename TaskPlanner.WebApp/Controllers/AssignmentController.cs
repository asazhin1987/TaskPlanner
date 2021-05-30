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
    public class AssignmentController : TaskPlannerController
	{
		public AssignmentController(ITaskPlannerService _src) : base(_src) { }

		[ActiveItem(MenuItem.MyTasks)]
		public IActionResult MyTasks()
        {
            return View();
        }

		[HttpGet]
		public IActionResult AdditionalMenu()
		{
			return PartialView("_AdditionalMenu", new AssignmentAdditionalMenuModel());
		}


		[HttpGet]
		public async Task<IActionResult> TasksPartial(ViewType ViewType)
		{
			if (ViewType == ViewType.Calendar)
				return await TasksCalendar();
			else if (ViewType == ViewType.Table)
				return await TasksTable();
			throw new Exception($"{Resources.Validations.WrongViewType}. ViewType: {ViewType}");
		}

		
		public async Task<IActionResult> TasksTable()
		{
			return PartialView("_Table");
		}

		public async Task<IActionResult> TasksCalendar()
		{
			return PartialView("_Calendar");
		}

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