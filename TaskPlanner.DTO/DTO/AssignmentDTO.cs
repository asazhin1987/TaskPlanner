using System;

namespace TaskPlanner.DTO
{
	public partial class AssignmentDTO
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public string Description { get; set; }

		public int? TypicalAssignmentId { get; set; }

		public string TypicalAssignmentName { get; set; }

		public int? ProjectId { get; set; }

		public int? StartHourId { get; set; }

		public int? StartMinuteId { get; set; }

		public TimeSpan StartTime { get; set; }

		public int? DurationHourId { get; set; }

		public int? DurationMinuteId { get; set; }

		public TimeSpan EndTime { get; set; }

		//public DateTime Date { get; set; }
	}
}
