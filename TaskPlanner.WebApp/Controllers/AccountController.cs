using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.DTO.Infrastructure;
using TaskPlanner.WebApp.Models;
using Mapper;
using TaskPlanner.DTO;
using Microsoft.AspNetCore.Authorization;


namespace TaskPlanner.WebApp.Controllers
{
	[AllowAnonymous]
	public class AccountController : TaskPlannerController
	{
		public AccountController(ITaskPlannerService _src) : base(_src) { }
       

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(SignInModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var userDto = await src.CheckUserAsync(model.MapTo(new UserDTO()));
					await Authenticate(userDto);
					return RedirectToAction("Index", "Home");
				}
				catch (NotFoundItemException)
				{
					ModelState.AddModelError(nameof(model.Login), Resources.Validations.WrongLogin);
				}
				catch (WrongPasswordException)
				{
					ModelState.AddModelError(nameof(model.Password), Resources.Validations.WrongPassword);
				}
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(SignUpModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var userDto = await src.RegistrUserAsync(model.MapTo(new UserDTO()));
					await Authenticate(userDto);
					return RedirectToAction("Index", "Home");
				}
				catch (UserExistsException)
				{
					ModelState.AddModelError(nameof(model.Login), Resources.Validations.ExistsLogin);
				}
				
				
			}
			return View(model);
		}

		[NonAction]
		private async Task Authenticate(UserDTO user)
		{
			// создаем один claim
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				//new Claim("DisplayName", user.DisplayName)
			};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}

	}
}