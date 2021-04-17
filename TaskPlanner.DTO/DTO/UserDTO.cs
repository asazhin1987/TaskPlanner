using System;
using System.Collections.Generic;


namespace TaskPlanner.DTO
{
	public partial class UserDTO
	{
		public int Id { get; set; }

		public string Email { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public string DisplayName { get; set; }
	}
}
