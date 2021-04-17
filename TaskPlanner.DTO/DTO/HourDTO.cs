using System;

namespace TaskPlanner.DTO
{
	public partial class HourDTO
	{
		public int Id { get; set; }

		public int Value { get; set; }

		public override string ToString()
		{
			return new TimeSpan(Value, 0, 0).ToString();
		}
	}
}
