using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TaskPlanner.DAL.Entities
{
	public class User
	{
		public int Id { get; set; }

		[StringLength(125)]
		public string Email { get; set; }

		[StringLength(125)]
		public string Password { get; set; }

		public ICollection<WTF> WTFs { get; set; }

		public User()
		{
			WTFs = new List<WTF>();
		}
	}
}
