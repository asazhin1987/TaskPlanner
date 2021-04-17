using System;
using TaskPlanner.DTO;


namespace TaskPlanner.WebApp.Models
{
	public class HourModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public HourModel(HourDTO dto)
		{
			Id = dto.Id;
			Name = new TimeSpan(dto.Value, 0, 0).ToString("hh");
		}
	}
}
