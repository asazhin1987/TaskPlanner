using Microsoft.Extensions.DependencyInjection;
using TaskPlanner.BLL.Infrastructure;

namespace TaskPlanner.WebApp.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddTaskPlannerDBService(this IServiceCollection services, string connStr)
		{
			services.AddTransient(service =>
			{
				return ServiceModule.CreateInstance(connStr);
			});
		}
	}
}
