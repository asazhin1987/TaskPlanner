using System;
using System.Collections.Generic;


namespace TaskPlanner.DTO
{
	public partial class TypicalAssignmentDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public IEnumerable<ProjectDTO> ProjectDTOs { get; set; }
	}
}
