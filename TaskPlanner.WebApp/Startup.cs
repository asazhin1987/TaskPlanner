using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using TaskPlanner.WebApp.Extensions;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using TaskPlanner.WebApp.Filters;

namespace TaskPlanner.WebApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			//db service
			string connection = Configuration.GetConnectionString("PlannerConnection");
			services.AddTaskPlannerDBService(connection);
			//cookie
			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => 
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
				});
			//filters
			services.AddControllersWithViews(options =>
			{
				options.Filters.Add(typeof(ActiveItemAttribute)); 
			});

			//razor
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
		}

	
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			var supportedCultures = new[]
			{
				new CultureInfo("en"),
				new CultureInfo("ru"),
			};

			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("ru"),
				SupportedCultures = supportedCultures,
				SupportedUICultures = supportedCultures
			});

			app.UseHttpsRedirection();
		
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();    // аутентификация
			app.UseAuthorization();     // авторизация

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
