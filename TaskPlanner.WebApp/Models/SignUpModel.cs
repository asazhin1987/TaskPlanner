using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.WebApp.Models
{
	/// <summary>
	/// Моделье регистрации пользователя
	/// </summary>
	public class SignUpModel
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

		/// <summary>
		/// ПОдтверждение пароля
		/// </summary>
		[Display(Name = nameof(ConfirmPassword), ResourceType = typeof(Resources.Fields))]
		[DataType(DataType.Password)]
		[MaxLength(25)]
		[Compare(nameof(Password), 
			ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "ConfirmPasswordFalse")]
		public string ConfirmPassword { get; set; }
	}
}
