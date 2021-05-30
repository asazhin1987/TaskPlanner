using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.WebApp.Application
{
	public enum MenuItem
	{

		Home,
		MyTasks,
		Calendar,
		ProjectManager,
		Settings,
		Plans,
		Team
	}


	public enum ViewType
	{
		Table, Calendar, Chart
	}

}
