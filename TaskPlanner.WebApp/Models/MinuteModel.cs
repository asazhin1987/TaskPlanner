
using TaskPlanner.DTO;

namespace TaskPlanner.WebApp.Models
{
	public class MinuteModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		
		public MinuteModel(MinuteDTO dto)
		{
			Id = dto.Id;
			Name = dto.Value < 10 ? $"0{dto.Value}" : dto.Value.ToString();
		}
	}
}
