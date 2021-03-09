using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.DAL.Interfaces;
using TaskPlanner.DTO;
using Mapper;

namespace TaskPlanner.BLL.Services
{
	public class TaskPlannerService : ITaskPlannerService
	{
		readonly IUnitOfWork db;

		public TaskPlannerService(IUnitOfWork uw)
		{
			db = uw;
		}

		public async Task<IEnumerable<HourDTO>> GetAllHoursAsync()
		{
			return (await db.Hours.GetAllAsync()).Select(x => x.MapTo(new HourDTO()));
		}
	}
}
