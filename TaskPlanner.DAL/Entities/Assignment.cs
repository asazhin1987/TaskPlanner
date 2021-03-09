using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskPlanner.DAL.Entities
{
	public class Assignment
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		public int? TypicalAssignmentId { get; set; }

		public TypicalAssignment TypicalAssignment { get; set; }

		public int? ProjectId { get; set; }

		public Project Project { get; set; }

		public int? StartHourId { get; set; }

		public Hour StartHour { get; set; }

		public int? StartMinuteId { get; set; }

		public Minute StartMinute { get; set; }

		public int? DurationHourId { get; set; }

		public Hour DurationHour { get; set; }

		public int? DurationMinuteId { get; set; }

		public Minute DurationMinute { get; set; }

		public DateTime Date { get; set; }

	}
}
