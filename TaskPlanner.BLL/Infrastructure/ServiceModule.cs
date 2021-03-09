using Ninject.Modules;
using TaskPlanner.DAL.Interfaces;
using TaskPlanner.DAL.Repositories;

namespace TaskPlanner.BLL.Infrastructure
{
	public class ServiceModule : NinjectModule
	{
		private readonly string connectionString;
		public ServiceModule(string connection)
		{
			connectionString = connection;
		}
		public override void Load()
		{

			Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
		}
	}
}
