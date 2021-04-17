using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.DAL.Entities
{
	[Owned]
	public class UserSetting
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public int? StartDayHourId { get; set; }

		public Hour StartDayHour { get; set; }

		public int? FinishDayHourId { get; set; }

		public Hour FinishDayHour { get; set; }

		public int? StartDurationHourId { get; set; }

		public Hour StartDurationHour { get; set; }

		public int? FinishDurationHourId { get; set; }

		public Hour FinishDurationHour { get; set; }

		public byte[] Avatar { get; set; }

		[StringLength(125)]
		public string Position { get; set; }

		[StringLength(255)]
		public string FullName { get; set; }

		[StringLength(500)]
		public string About { get; set; }
	}
}
