using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.DTO;

namespace TaskPlanner.WebApp.Models
{
	public class ProjectTypicalAssignmentModel
	{
		public IEnumerable<ProjectModel> Projects { get; set; }

		public IEnumerable<TypicalAssignmentModel> TypicalAssignments { get; set; }
		
		

		public ProjectTypicalAssignmentModel()
		{
			Projects = new List<ProjectModel>();
			TypicalAssignments = new List<TypicalAssignmentModel>();
		}

		public ProjectTypicalAssignmentModel(IEnumerable<ProjectDTO> projects, IEnumerable<TypicalAssignmentDTO> tasks)
		{
			Projects = projects.Select(x => (ProjectModel)x);
			TypicalAssignments = tasks.Select(x => (TypicalAssignmentModel)x);
			
		}

	}
}
