using System;
using System.Collections.Generic;

namespace TaskPlanner.DTO
{
	public partial class ProjectDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Color { get; set; }

		public bool IsDesigned { get; set; }

		public string Description { get; set; }

		public IEnumerable<UserDTO> UserDTOs { get; set; }
	}
}
