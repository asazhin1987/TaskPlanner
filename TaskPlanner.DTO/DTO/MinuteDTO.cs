
namespace TaskPlanner.DTO
{
	public class MinuteDTO
	{
		public int Id { get; set; }

		public int Value { get; set; }

		public override string ToString()
		{
			return Value.ToString("D2");
		}
	}
}
