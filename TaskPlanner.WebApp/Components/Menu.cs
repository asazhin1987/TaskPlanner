using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.WebApp.Models;
using TaskPlanner.WebApp.Application;
using TaskPlanner.WebApp.Extensions;
using TaskPlanner.DTO.Infrastructure;

namespace TaskPlanner.WebApp.Components
{
	public class Menu : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View(new MenuModel()
			{
				Items = new List<LinkMenuModel>
				 {
					new LinkMenuModel() { ActionName = "MyTasks", ControllerName = "Assignment", Image = "clock-32.png", MenuItem = Enums.MenuItem.MyTasks, Title = Resources.Menu.MyTasks  },
					//new LinkMenuModel() { ActionName = "", ControllerName = "", Image = "day-32.png", MenuItem = Enums.MenuItem.Calendar, Title = Resources.Menu.Calendar  },
					new LinkMenuModel() { ActionName = "ProjectsAndTasks", ControllerName = "Project", Image = "project-32.png", MenuItem = Enums.MenuItem.ProjectManager, Title = Resources.Menu.ProjectsAndTasks  },
					new LinkMenuModel() { ActionName = "MyGrandPlans", ControllerName = "Plan", Image = "planner-32.png", MenuItem = Enums.MenuItem.Plans, Title = Resources.Menu.WorkingTime  },
					new LinkMenuModel() { ActionName = "MyParams", ControllerName = "Settings", Image = "myspace-32.png", MenuItem = Enums.MenuItem.Settings , Title = Resources.Menu.Settings},
					new LinkMenuModel() { ActionName = "MyTeam", ControllerName = "Team", Image = "conference-32.png", MenuItem = Enums.MenuItem.Team , Title = Resources.Menu.MyTeam},
				 }
			});
		}
	}
}
