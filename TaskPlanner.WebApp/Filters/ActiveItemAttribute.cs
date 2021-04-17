using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TaskPlanner.WebApp.Application.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskPlanner.WebApp.Controllers;

namespace TaskPlanner.WebApp.Filters
{
	public class ActiveItemAttribute : Attribute, IResultFilter
	{
		public MenuItem Item { get; }

		public ActiveItemAttribute(MenuItem item = MenuItem.Home)
		{
			this.Item = item;
		}

		public void OnResultExecuting(ResultExecutingContext filterContext) =>
			((TaskPlannerController)filterContext.Controller).TempData["ActiveItem"] = Item;


		public void OnResultExecuted(ResultExecutedContext filterContext)
		{

		}
	}
}
