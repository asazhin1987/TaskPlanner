using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TaskPlanner.DAL.Entities
{
	public class User
	{
		public int Id { get; set; }

		[StringLength(50)]
		public string Email { get; set; }

		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(25)]
		public string Login { get; set; }

		[StringLength(25)]
		public string Password { get; set; }

		public UserSetting UserSetting { get; set; }

		public ICollection<WTF> WTFs { get; set; }

		public ICollection<Project> Projects { get; set; }

		public ICollection<TypicalAssignment> TypicalAssignments { get; set; }

		public virtual ICollection<Team> TeamsParticipation { get; set; }

		public ICollection<ProjectAssignmentRelation> ProjectAssignmentRelations { get; set; }

		public User()
		{
			WTFs = new List<WTF>();
			Projects = new List<Project>();
			TypicalAssignments = new List<TypicalAssignment>();
			TeamsParticipation = new List<Team>();
			ProjectAssignmentRelations = new List<ProjectAssignmentRelation>();
		}
	}
}
