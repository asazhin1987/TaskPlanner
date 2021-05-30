using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.WebApp.Application;

using TaskPlanner.WebApp.Application;

namespace TaskPlanner.WebApp.Models
{
	
	public class MenuModel
	{
		public IEnumerable<LinkMenuModel> Items { get; set; }
	}

	public class GroupMenuViewModel
	{
		public string Title { get; set; }
		public ICollection<LinkMenuModel> Items { get; set; }
	}

	public class LinkMenuModel
	{
		public string Title { get; set; }
		public string Image { get; set; }
		public string ControllerName { get; set; }
		public string ActionName { get; set; }
		public MenuItem MenuItem { get; set; }
	}

	public class AssignmentAdditionalMenuModel
	{
		public ViewType ViewType { get; set; }


		public AssignmentAdditionalMenuModel(ViewType viewType = ViewType.Calendar)
		{
			ViewType = viewType;
		}

		
	}
}
