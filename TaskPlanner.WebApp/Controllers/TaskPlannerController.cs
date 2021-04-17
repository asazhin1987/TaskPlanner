using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.WebApp.Extensions;

namespace TaskPlanner.WebApp.Controllers
{
	[Authorize]
    public class TaskPlannerController : Controller
    {
		internal readonly ITaskPlannerService src;
		internal int UserId { get { return GetUserId(); } }

		public TaskPlannerController(ITaskPlannerService _src)
		{
			src = _src;
		}


		private int GetUserId() =>
			User.GetUserId();

		
	}
}