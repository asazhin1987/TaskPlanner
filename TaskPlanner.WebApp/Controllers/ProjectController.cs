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
using Mapper;

using TaskPlanner.WebApp.Application;

namespace TaskPlanner.WebApp.Controllers
{
	public class ProjectController : TaskPlannerController
	{
		public ProjectController(ITaskPlannerService _src) : base(_src) { }

		[ActiveItem(MenuItem.ProjectManager)]
		public IActionResult ProjectsAndTasks()
		{
			return View();
		}

		

		public async Task<IActionResult> ProjectsAndTasksTable()
		{
			return PartialView("_ProjectsAndTasksTable", new ProjectTypicalAssignmentModel(
				await src.GetProjectsAsync(UserId), await src.GetAllTypicalAssignmentsAsync(UserId)));
		}

		[HttpPost]
		public async Task<string> ToggleProjectTask(int taskId, int projectId, bool chcd)
		{
			await src.ToggleProjectAssignment(taskId, projectId, UserId, chcd);
			return "";
		}

		[HttpGet]
		public IActionResult AdditionalMenu() =>
			PartialView("_AdditionalMenu");

		#region project 
		[HttpGet]
		public IActionResult CreateProject()
		{
			return PartialView("_ProjectMerge", new ProjectModel() { Id = 0 });
		}

	
		[HttpGet]
		public async Task<IActionResult> EditProject(int Id)
		{
			var item = await src.GetProjectAsync(Id, UserId);
			return PartialView("_ProjectMerge", item.MapTo(new ProjectModel()));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MergeProject(ProjectModel model )
		{
			if (ModelState.IsValid)
			{
				await src.MergeProjectAsync(new ProjectDTO().MapOn(model), UserId);
				return PartialView("_ResultView");
			}
			return PartialView("_ProjectMerge");
		}


		#endregion project


		#region relations


		#endregion relations

		#region typical assignments

		[HttpGet]
		public IActionResult CreateTypicalAssignment()
		{
			return PartialView("_MergeTypicalAssignment", new TypicalAssignmentModel() {Id = 0 });
		}

		[HttpGet]
		public async Task<IActionResult> EditTypicalAssignment(int Id)
		{

			var item = await src.GetTypicalAssignmentAsync(Id, UserId);
			return PartialView("_MergeTypicalAssignment", item.MapTo(new TypicalAssignmentModel()));
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MergeTypicalAssignmen(TypicalAssignmentModel model)
		{
			if (ModelState.IsValid)
			{
				await src.MergeTypicalAssignmentAsync(new TypicalAssignmentDTO().MapOn(model), UserId);
				return PartialView("_ResultView");
			}
			return PartialView("_MergeTypicalAssignment");
		}

		#endregion typical assignments
	}
}