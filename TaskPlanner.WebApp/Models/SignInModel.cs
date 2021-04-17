using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.WebApp.Models
{
	/// <summary>
	/// Модель входа пользователя в систему
	/// </summary>
	public class SignInModel
	{
		/// <summary>
		/// Логин
		/// </summary>
		[Display(Name = nameof(Login), ResourceType = typeof(Resources.Fields))]
		[Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "NullLogin")]
		[MaxLength(25)]
		public string Login { get; set; }

		/// <summary>
		/// Пароль
		/// </summary>
		[Display(Name = nameof(Password), ResourceType = typeof(Resources.Fields))]
		[Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "NullPassword")]
		[DataType(DataType.Password)]
		[MaxLength(25)]
		public string Password { get; set; }
	}
}
