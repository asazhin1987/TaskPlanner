
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.DAL.Entities
{
	public class TypicalAssignment
	{
		public int Id { get; set; }

		[StringLength(125)]
		public string Name { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		//public ICollection<Project> Projects { get; set; }

		public ICollection<Assignment> Assignments { get; set; }

		public ICollection<ProjectAssignmentRelation> ProjectAssignmentRelations { get; set; }

		public ICollection<User> Users { get; set; }

		public TypicalAssignment()
		{
			//Projects = new List<Project>();
			Assignments = new List<Assignment>();
			ProjectAssignmentRelations = new List<ProjectAssignmentRelation>();
			Users = new List<User>();
		}
	}
}
