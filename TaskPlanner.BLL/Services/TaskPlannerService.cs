using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.BLL.Interfaces;
using TaskPlanner.DAL.Interfaces;
using TaskPlanner.DTO;
using Mapper;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.DTO.Infrastructure;
using TaskPlanner.DAL.Entities;

namespace TaskPlanner.BLL.Services
{
	internal class TaskPlannerService : ITaskPlannerService
	{
		readonly IUnitOfWork db;

		public TaskPlannerService(IUnitOfWork uw)
		{
			db = uw;
		}

		#region user
		public async Task<UserDTO> CheckUserAsync(UserDTO user)
		{
			var userlogin = db.Users.GetAll().Where(x => x.Login == user.Login);
			if (await userlogin.FirstOrDefaultAsync() == null)
				throw new NotFoundItemException();
			var users = await userlogin.Where(x => x.Password == user.Password).FirstOrDefaultAsync();
			if (users == null)
				throw new WrongPasswordException();

			var result = users.MapTo(new UserDTO());
			//result.DisplayName = users.Login;
			return result;
		}

		public async Task<UserDTO> RegistrUserAsync(UserDTO user)
		{
			var userlogin = db.Users.GetAll().Where(x => x.Login == user.Login);
			if (await userlogin.FirstOrDefaultAsync() != null)
				throw new UserExistsException();
			var newuser = user.MapTo(new User());
			await db.Users.CreateAsync(newuser);
			var result = newuser.MapTo(new UserDTO());
			//result.DisplayName = newuser.Login;
			return result;
		}

		public async Task<UserDTO> GetUserAsync(int Id)
		{
			var user = await db.Users.GetAsync(Id);
			if (user == null)
				throw new NotFoundItemException();
			var result = user.MapTo(new UserDTO());
			result.DisplayName = user.Login;
			return result;
		}

		#endregion user

		#region project

		#region CRUD

		public async Task MergeProjectAsync(ProjectDTO item, int userId)
		{
			if (item.Id == 0)
				await CreateProjectAsync(item, userId);
			else
				await UpdateProjectAsync(item, userId);
		}

		public async Task CreateProjectAsync(ProjectDTO item, int userId)
		{
			var _item = new Project().MapOn(item);
			await db.Projects.CreateAsync(_item);
			await AddProjectUsers(_item, new List<int> { userId });
		}

		public async Task UpdateProjectAsync(ProjectDTO item, int userId)
		{
			var project = await db.Projects.GetAsync(item.Id);
			if (project == null)
				throw new NotFoundItemException();

			project.MapOn(item);
			await db.Projects.UpdateAsync(project);
		}

		public async Task<ProjectDTO> GetProjectAsync(int Id, int userId)
		{
			//проверить на принадлежность пользователя
			var project = await db.Projects.GetAsync(Id);
			if (project == null)
				throw new NotFoundItemException();
			return new ProjectDTO().MapOn(project);
		}


		public async Task AddProjectUsers(int projectId, IEnumerable<int> userIds)
		{
			var project = await db.Projects.GetAsync(projectId);
			if (project == null)
				throw new NotFoundItemException();
			await AddProjectUsers(project, userIds);
		}

		private async Task AddProjectUsers(Project project, IEnumerable<int> userIds)
		{
			var users = await db.Users.GetAll().Where(x => userIds.Contains(x.Id)).ToListAsync();
			foreach (var user in users)
				project.Users.Add(user);
			await db.Projects.UpdateAsync(project);
		}


		#endregion CRUD


		#region relations

		public async Task ToggleProjectAssignment(int assignId, int projectId, int userId, bool _checked)
		{
			if (_checked)
				await CreateProjectAssignmentRelation(assignId, projectId, userId);
			else
				await RemoveProjectAssignmentRelation(assignId, projectId, userId);
		}

		public async Task CreateProjectAssignmentRelation(int assignId, int projectId, int userId)
		{
			var rel = await db.ProjectAssignmentRelations.GetAll()
				.Where(x => x.ProjectId == projectId && x.UserId == userId && x.TypicalAssignmentId == assignId).FirstOrDefaultAsync();
			if(rel == null)
				await db.ProjectAssignmentRelations.CreateAsync(new ProjectAssignmentRelation()
				{
					UserId = userId, ProjectId = projectId, TypicalAssignmentId = assignId
				});
		}

		public async Task RemoveProjectAssignmentRelation(int assignId, int projectId, int userId)
		{
			var rel = await db.ProjectAssignmentRelations.GetAll()
				.Where(x => x.ProjectId == projectId && x.UserId == userId && x.TypicalAssignmentId == assignId).FirstOrDefaultAsync();
			if (rel != null)
				await db.ProjectAssignmentRelations.DeleteAsync(rel);
		}


		#endregion relations

		#region getfiltered

		public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync(int userId)
		{
			var user = await db.Users.GetAsync(userId);
			return await db.Projects.GetAll().Where(x => x.Users.Contains(user)).Select(x =>
			new ProjectDTO()
			{
				Id = x.Id,
				IsDesigned = x.IsDesigned,
				Name = x.Name,
				Color = x.Color,
				Description = x.Description
			}).AsNoTracking().ToListAsync();
		}

		#endregion getfiltered

		#endregion project


		#region Typical assignments

		#region CRUD

		public async Task MergeTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId)
		{
			if (item.Id == 0)
				await CreateTypicalAssignmentAsync(item, userId);
			else
				await UpdateTypicalAssignmentAsync(item, userId);
		}

		public async Task CreateTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId)
		{
			var _item = new TypicalAssignment().MapOn(item);
			await db.TypicalAssignments.CreateAsync(_item);
			await AddTypicalAssignmentUsers(_item, new List<int> {userId });
		}

		public async Task UpdateTypicalAssignmentAsync(TypicalAssignmentDTO item, int userId)
		{
			var _item = await db.TypicalAssignments.GetAsync(item.Id);
			if (_item == null)
				throw new NotFoundItemException();
			_item.MapOn(item);
			await db.TypicalAssignments.UpdateAsync(_item);
		}

		public async Task RemoveTypicalAssignmentAsync(int Id, int userId)
		{
			throw new NotImplementedException();
		}

		private async Task AddTypicalAssignmentUsers(TypicalAssignment task, IEnumerable<int> userIds)
		{
			var users = await db.Users.GetAll().Where(x => userIds.Contains(x.Id)).ToListAsync();
			foreach (var user in users)
				task.Users.Add(user);
			await db.TypicalAssignments.UpdateAsync(task);
		}



		#endregion CROD

		public async Task<IEnumerable<TypicalAssignmentDTO>> GetTypicalAssignmentsAsync(int projectId, int userId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<TypicalAssignmentDTO>> GetAllTypicalAssignmentsAsync(int userId)
		{
			var user = await db.Users.GetAsync(userId);
			try
			{
				return await db.TypicalAssignments.GetAll().Where(x => x.Users.Contains(user)).Select(x =>
			new TypicalAssignmentDTO()
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				ProjectDTOs = x.ProjectAssignmentRelations.Where(x => x.UserId == userId).Select(p => new ProjectDTO()
				{
					Id = p.ProjectId,
					//UserDTOs = p.Users.Select(u => new UserDTO
					//{
					//	Id = u.Id
					//})
				})
			}).AsNoTracking().ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		
		public async Task<TypicalAssignmentDTO> GetTypicalAssignmentAsync(int Id, int userId)
		{
			var item = await db.TypicalAssignments.GetAsync(Id);
			if (item == null)
				throw new NotFoundItemException();
			return new TypicalAssignmentDTO().MapOn(item);
		}



		#endregion Typical assignments

		#region team

		public async Task CreateTeamAsync(TeamDTO item, int userId)
		{
			
			Team team = new Team().MapOn(item);
			await db.Teams.CreateAsync(team);
			await ConnectToTeamAsync(team.Id, userId);
		}

		public async Task ConnectToTeamAsync(int teamId, int userId)
		{
			User user = await db.Users.GetAsync(userId);
			Team team = await db.Teams.GetAsync(teamId);
			if (team == null || user == null)
				throw new NotFoundItemException();
			user.TeamsParticipation.Add(team);
			await db.Users.UpdateAsync(user);
		}

		
		public async Task UpdateTeamAsync(TeamDTO item, int userId)
		{
			Team team = await db.Teams.GetAsync(item.Id);
			if (team == null)
				throw new NotFoundItemException();
			team.MapOn(item);
			await db.Teams.UpdateAsync(team);
		}

		public async Task<TeamDTO> GetTeamAsync(int Id, int userId)
		{
			Team team = await db.Teams.GetAsync(Id);
			if (team == null)
				throw new NotFoundItemException();
			return new TeamDTO().MapOn(team);
		}

		public async Task MergeTeamAsync(TeamDTO item, int userId)
		{
			if (item.Id == 0)
				await CreateTeamAsync(item, userId);
			else
				await UpdateTeamAsync(item, userId);
		}


		public async Task ConnectToTeamsAsync(IEnumerable<int> teamIds, int userId)
		{
			if (teamIds != null)
				foreach (int id in teamIds)
					await ConnectToTeamAsync(id, userId);
		}

		public async Task LeaveTeamAsync(int teamId, int userId)
		{
			User user = await db.Users.GetAsync(userId);
			Team team = await db.Teams.GetAsync(teamId);
			if (team == null || user == null)
				throw new NotFoundItemException();
			user.TeamsParticipation.Remove(team);
			await db.Users.UpdateAsync(user);
		}


		#endregion team

		public Task CreateAssignmentAsync(AssignmentDTO item)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<HourDTO>> GetAllHoursAsync()
		{
			return (await db.Hours.GetAllAsync()).Select(x => x.MapTo(new HourDTO()));
		}

		public async Task<IEnumerable<MinuteDTO>> GetAllMinutesAsync()
		{
			throw new NotImplementedException();
		}


		public Task<AssignmentDTO> GetAssignmentAsync(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<HourDTO>> GetDurationHoursAsync()
		{
			throw new NotImplementedException();
		}

		

		public async Task<IEnumerable<HourDTO>> GetWorkingHoursAsync()
		{
			throw new NotImplementedException();
		}

		

		public Task RemoveAssignmentAsync(int Id)
		{
			throw new NotImplementedException();
		}

		public Task RemoveProjectAsync(int Id)
		{
			throw new NotImplementedException();
		}

	

		public Task UpdateAssignmentAsync(AssignmentDTO item)
		{
			throw new NotImplementedException();
		}

		
	}
}
