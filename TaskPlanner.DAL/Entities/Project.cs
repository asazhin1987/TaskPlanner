﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.DAL.Entities
{
	public class Project
	{
		public int Id { get; set; }

		[StringLength(125)]
		public string Name { get; set; }

		[StringLength(6)]
		public string Color { get; set; }

		public bool IsDesigned { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		//public ICollection<TypicalAssignment> TypicalAssignments { get; set; }

		public ICollection<ProjectAssignmentRelation> ProjectAssignmentRelations { get; set; }

		public ICollection<User> Users { get; set; }

		public Project()
		{
			//TypicalAssignments = new List<TypicalAssignment>();
			ProjectAssignmentRelations = new List<ProjectAssignmentRelation>();
			Users = new List<User>();
		}

	}
}
