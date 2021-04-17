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
    public class PlanController : TaskPlannerController
	{
		public PlanController(ITaskPlannerService _src) : base(_src) { }

		[ActiveItem(MenuItem.Plans)]
		public IActionResult MyGrandPlans()
        {
            return View();
        }
    }
}