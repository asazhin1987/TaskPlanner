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
		Task<IEnumerable<HourDTO>> GetWorkingHoursAsync();
		Task<IEnumerable<HourDTO>> GetDurationHoursAsync();
		//Minute
		Task<IEnumerable<MinuteDTO>> GetAllMinutesAsync();
		//calendar
		IEnumerable<MonthDTO> GetAllMonths(int year);
		IEnumerable<WeekDayDTO> GetWeekDays();

		//Typical Assignment
		Task MergeTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId);
		Task CreateTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId);
		Task<TypicalAssignmentDTO> GetTypicalAssignmentAsync(int Id, int userId);
		Task UpdateTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId);
		Task RemoveTypicalAssignmentAsync(int Id, int userId);
		Task<IEnumerable<TypicalAssignmentDTO>> GetAllTypicalAssignmentsAsync(int userId);
		Task<IEnumerable<TypicalAssignmentDTO>> GetTypicalAssignmentsAsync(int projectId, int userId);
		Task ToggleProjectAssignment(int assignId, int projectId, int userId, bool _checked);
		Task CreateProjectAssignmentRelation(int assignId, int projectId, int userId);
		Task RemoveProjectAssignmentRelation(int assignId, int projectId, int userId);

		//Assignment
		Task CreateAssignmentAsync(AssignmentDTO item);
		Task<AssignmentDTO> GetAssignmentAsync(int Id);
		Task UpdateAssignmentAsync(AssignmentDTO item);
		Task RemoveAssignmentAsync(int Id);

		//Project
		Task CreateProjectAsync(ProjectDTO item, int userId);
		Task UpdateProjectAsync(ProjectDTO item, int userId);
		Task MergeProjectAsync(ProjectDTO item, int userId);
		Task AddProjectUsers(int projectId, IEnumerable<int> userIds);
		Task<ProjectDTO> GetProjectAsync(int Id, int userId);
		Task<IEnumerable<ProjectDTO>> GetProjectsAsync(int userId);
		
		Task RemoveProjectAsync(int Id);
		//user
		Task<UserDTO> CheckUserAsync(UserDTO user);
		Task<UserDTO> RegistrUserAsync(UserDTO user);
		Task<UserDTO> GetUserAsync(int Id);

		//Team
		Task CreateTeamAsync(TeamDTO item, int userId);
		Task UpdateTeamAsync(TeamDTO item, int userId);
		Task<TeamDTO> GetTeamAsync(int Id, int userId);
		Task MergeTeamAsync(TeamDTO item, int userId);
		Task ConnectToTeamAsync(int teamId, int userId);
		Task ConnectToTeamsAsync(IEnumerable<int> teamIds, int userId);
		Task LeaveTeamAsync(int teamId, int userId);
	}
}
