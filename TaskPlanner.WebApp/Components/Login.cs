using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.WebApp.Models;
using TaskPlanner.WebApp.Extensions;
using TaskPlanner.DTO.Infrastructure;

namespace TaskPlanner.WebApp.Components
{
	public class Login : ViewComponent
	{
		readonly ITaskPlannerService src;
		public Login(ITaskPlannerService _src)
		{
			src = _src;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			UserModel model = new UserModel();
			int Id = UserClaimsPrincipal.GetUserId();
			
			if (Id > 0)
			{
				try
				{
					var user = await src.GetUserAsync(Id);
					model.IsAuthenticated = true;
					model.Name = user.DisplayName;
				}
				catch (NotFoundItemException)
				{

				}
			}
				
			return View(model);
		}
	}
}
