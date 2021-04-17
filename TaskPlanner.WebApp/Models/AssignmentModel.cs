using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskPlanner.DTO;
using Mapper;

namespace TaskPlanner.WebApp.Models
{
	public class AssignmentModel
	{
		/// <summary>
		/// ID идентификатор
		/// </summary>
		[ScaffoldColumn(false)]
		[Display(Name = nameof(Id), ResourceType = typeof(Resources.Fields))]
		public int Id { get; set; }

		/// <summary>
		/// Пользователь
		/// </summary>
		[Display(Name = "User", ResourceType = typeof(Resources.Fields))]
		[ScaffoldColumn(false)]
		public int UserId { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		[MaxLength(125)]
		[Display(Name = nameof(Name), ResourceType = typeof(Resources.Fields))]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Примечание
		/// </summary>
		[MaxLength(255)]
		[Display(Name = nameof(Description), ResourceType = typeof(Resources.Fields))]
		public string Description { get; set; }

		/// <summary>
		/// ID Типовой задачи
		/// </summary>
		[ScaffoldColumn(false)]
		[Display(Name = "TypicalAssignment", ResourceType = typeof(Resources.Fields))]
		public int TypicalAssignmentId { get; set; }

		/// <summary>
		/// Проект
		/// </summary>
		[ScaffoldColumn(false)]
		[Display(Name = "Project", ResourceType = typeof(Resources.Fields))]
		public int ProjectId { get; set; }

		/// <summary>
		/// начало, ID часа
		/// </summary>
		[Display(Name = "StartTime", ResourceType = typeof(Resources.Fields))]
		[ScaffoldColumn(false)]
		public int? StartHourId { get; set; }

		/// <summary>
		/// Начало, ID мин
		/// </summary>
		[Display(Name = "StartTime", ResourceType = typeof(Resources.Fields))]
		[ScaffoldColumn(false)]
		public int? StartMinuteId { get; set; }

		/// <summary>
		/// Длительность, ID часа
		/// </summary>
		[Display(Name = "DurationTime", ResourceType = typeof(Resources.Fields))]
		[ScaffoldColumn(false)]
		public int? DurationHourId { get; set; }

		/// <summary>
		/// Длительность, ID мин
		/// </summary>
		[Display(Name = "DurationTime", ResourceType = typeof(Resources.Fields))]
		[ScaffoldColumn(false)]
		public int? DurationMinuteId { get; set; }

	}
}
