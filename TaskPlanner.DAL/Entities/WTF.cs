using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskPlanner.DAL.Entities
{
	public class WTF
	{
		[Key]
		[Column(Order = 0)]
		public int MonthId { get; set; }

		[Key]
		[Column(Order = 1)]
		public int UserId { get; set; }

		public User User { get; set; }

		public int CapitalizedTime { get; set; }

		public int NonCapitalizableTime { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

	}
}
