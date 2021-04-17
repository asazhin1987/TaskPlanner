using TaskPlanner.DAL.Repositories;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.BLL.Services;

namespace TaskPlanner.BLL.Infrastructure
{
	public class ServiceModule 
	{
		public static ITaskPlannerService CreateInstance(string connection)
		{
			return new TaskPlannerService(new EFUnitOfWork(connection));
		}
	}
}
