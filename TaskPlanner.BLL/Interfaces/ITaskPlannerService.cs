using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.DTO;

namespace TaskPlanner.BLL.Interfaces
{
	public interface ITaskPlannerService
	{
		//Hour
		Task<IEnumerable<HourDTO>> GetAllHoursAsync();
	}
}
