using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.DAL.Entities
{
	public class Team
	{
		public int Id { get; set; }

		[StringLength(125)]
		public string Name { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		public byte[] Avatar { get; set; }

		public virtual ICollection<User> Participants { get; set; }

		public Team()
		{
			Participants = new List<User>();
		}
	}
}
