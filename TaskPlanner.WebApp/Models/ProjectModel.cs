using System.ComponentModel.DataAnnotations;
using TaskPlanner.DTO;
using Mapper;
namespace TaskPlanner.WebApp.Models
{
	/// <summary>
	/// Модель проекта
	/// </summary>
	public class ProjectModel
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
		/// Метка цвета
		/// </summary>
		[MaxLength(6)]
		[Display(Name = nameof(Color), ResourceType = typeof(Resources.Fields))]
		public string Color { get; set; }

		/// <summary>
		/// Признак капитализации, true если капитализируемый
		/// </summary>
		[ScaffoldColumn(false)]
		[Display(Name = nameof(IsDesigned), ResourceType = typeof(Resources.Fields))]
		public bool IsDesigned { get; set; }

		/// <summary>
		/// Примечание
		/// </summary>
		[MaxLength(255)]
		[Display(Name = nameof(Description), ResourceType = typeof(Resources.Fields))]
		public string Description { get; set; }


		public ProjectModel() { }

		public ProjectModel(ProjectDTO dto)
		{
			dto.MapTo(this);
		}

		public static implicit operator ProjectModel(ProjectDTO dto) => new ProjectModel(dto);
	}
}
