using System;
using TaskPlanner.DAL.EF;
using TaskPlanner.DAL.Interfaces;
using TaskPlanner.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace TaskPlanner.DAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		readonly TaskPlannerContext db;

		UserRepository userRepository;
		ProjectRepository projectRepository;
		TypicalAssignmentRepository typicalAssignmentRepository;
		AssignmentRepository assignmentRepository;
		HourRepository hourRepository;
		MinuteRepository minuteRepository;
		WTFRepository wtfRepository;
		ProjectAssignmentRelationRepository projectAssignmentRelationRepository;
		TeamRepository teamRepository;

		public EFUnitOfWork(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<TaskPlannerContext>();
			var options = optionsBuilder
					.UseSqlServer(connectionString)
					.Options;
			db = new TaskPlannerContext(options);
		}

		public EFUnitOfWork(TaskPlannerContext context)
		{
			db = context;
		}

		#region repo
		public IRepository<User> Users
		{
			get
			{
				if (userRepository == null)
					userRepository = new UserRepository(db);
				return userRepository;
			}
		}

		public IRepository<Project> Projects
		{
			get
			{
				if (projectRepository == null)
					projectRepository = new ProjectRepository(db);
				return projectRepository;
			}
		}


		public IRepository<TypicalAssignment> TypicalAssignments
		{
			get
			{
				if (typicalAssignmentRepository == null)
					typicalAssignmentRepository = new TypicalAssignmentRepository(db);
				return typicalAssignmentRepository;
			}
		}


		public IRepository<Assignment> Assignments
		{
			get
			{
				if (assignmentRepository == null)
					assignmentRepository = new AssignmentRepository(db);
				return assignmentRepository;
			}
		}

		public IRepository<Hour> Hours
		{
			get
			{
				if (hourRepository == null)
					hourRepository = new HourRepository(db);
				return hourRepository;
			}
		}

		public IRepository<Minute> Minutes
		{
			get
			{
				if (minuteRepository == null)
					minuteRepository = new MinuteRepository(db);
				return minuteRepository;
			}
		}

		public IRepository<WTF> WTFs
		{
			get
			{
				if (wtfRepository == null)
					wtfRepository = new WTFRepository(db);
				return wtfRepository;
			}
		}

		public IRepository<ProjectAssignmentRelation> ProjectAssignmentRelations
		{
			get
			{
				if (projectAssignmentRelationRepository == null)
					projectAssignmentRelationRepository = new ProjectAssignmentRelationRepository(db);
				return projectAssignmentRelationRepository;
			}
		}

		public IRepository<Team> Teams
		{
			get
			{
				if (teamRepository == null)
					teamRepository = new TeamRepository(db);
				return teamRepository;
			}
		}


		#endregion repo






		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
