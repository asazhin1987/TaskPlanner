using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskPlanner.DTO;
using Mapper;

namespace TaskPlanner.WebApp.Models
{
	/// <summary>
	/// Типовая задача
	/// </summary>
	public class TypicalAssignmentModel
	{
		/// <summary>
		/// ID идентификатор
		/// </summary>
		[ScaffoldColumn(false)]
		[Display(Name = nameof(Id), ResourceType = typeof(Resources.Fields))]
		public int Id { get; set; }

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

		[ScaffoldColumn(false)]
		[NotMapped]
		public IEnumerable<ProjectDTO> ProjectDTOs { get; set; }

		public TypicalAssignmentModel() { }

		public TypicalAssignmentModel(TypicalAssignmentDTO dto)
		{
			dto.MapTo(this);
			ProjectDTOs = dto.ProjectDTOs.ToList();
		}

		public static implicit operator TypicalAssignmentModel(TypicalAssignmentDTO dto) => new TypicalAssignmentModel(dto);
	}
}
