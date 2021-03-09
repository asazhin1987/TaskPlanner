using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

using TaskPlanner.DAL.EF;
using TaskPlanner.DAL.Interfaces;
using TaskPlanner.DAL.Entities;
using TaskPlanner.DAL.Repositories;





namespace TaskPlanner.Tests
{
	[TestClass]
	public class DALTests
	{

		TaskPlannerContext db;
		IUnitOfWork src;

		#region init data

		readonly IEnumerable<User> users = new List<User>
		{
			new User { Id = 1, Email  = "email 1", Password = "111" },
			new User { Id = 2, Email  = "email 2", Password = "111" },
			new User { Id = 3, Email  = "email 3", Password = "111" },
		};

		Project p1 = new Project { Id = 1, Name = "Project 1", IsDesigned = false };
		Project p2 = new Project { Id = 2, Name = "Project 2", IsDesigned = true };
		Project p3 = new Project { Id = 3, Name = "Project 3", IsDesigned = true };

		TypicalAssignment a1 = new TypicalAssignment { Id = 1, Name = "TypicalAssignment 1" };
		TypicalAssignment a2 = new TypicalAssignment { Id = 2, Name = "TypicalAssignment 2" };
		TypicalAssignment a3 = new TypicalAssignment { Id = 3, Name = "TypicalAssignment 3" };
		
		readonly IEnumerable<Assignment> assignments = new List<Assignment>
		{
			new Assignment { Id = 1, ProjectId = 1, TypicalAssignmentId  = 1, UserId = 1, StartMinuteId =1, StartHourId = 1, DurationHourId = 2, DurationMinuteId = 1, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 2, ProjectId = 1, TypicalAssignmentId  = 1, UserId = 1, StartMinuteId =1, StartHourId = 2, DurationHourId = 2, DurationMinuteId = 1, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 3, ProjectId = 1, TypicalAssignmentId  = 2, UserId = 1, StartMinuteId =1, StartHourId = 3, DurationHourId = 2, DurationMinuteId = 1, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 4, ProjectId = 2, TypicalAssignmentId  = 2, UserId = 1, StartMinuteId =1, StartHourId = 4, DurationHourId = 2, DurationMinuteId = 2, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 5, ProjectId = 2, TypicalAssignmentId  = 2, UserId = 1, StartMinuteId =1, StartHourId = 6, DurationHourId = 2, DurationMinuteId = 2, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 6, ProjectId = 2, TypicalAssignmentId  = 2, UserId = 1, StartMinuteId =1, StartHourId = 7, DurationHourId = 2, DurationMinuteId = 1, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 7, ProjectId = 3, TypicalAssignmentId  = 1, UserId = 1, StartMinuteId =1, StartHourId = 8, DurationHourId = 1, DurationMinuteId = 2, Date = new DateTime(2021, 01, 01) },
			new Assignment { Id = 8, ProjectId = 3, TypicalAssignmentId  = 3, UserId = 1, StartMinuteId =1, StartHourId = 8, DurationHourId = 1, DurationMinuteId = 2, Date = new DateTime(2021, 01, 01) },
		};

		#endregion init data

		[TestInitialize]
		public void Initialize()
		{
			DataInicialize();
		}

		void DataInicialize()
		{
			string dbName = Guid.NewGuid().ToString();
			DbContextOptions<TaskPlannerContext> options = new DbContextOptionsBuilder<TaskPlannerContext>()
				   .UseInMemoryDatabase(databaseName: dbName).Options;

			db = new TaskPlannerContext(options);
			src = new EFUnitOfWork(db);

			db.Users.AddRange(users);
			db.SaveChanges();
			db.TypicalAssignments.AddRange(new List<TypicalAssignment> { a1, a2, a3 });

			p1.TypicalAssignments.Add(a1);
			p1.TypicalAssignments.Add(a2);
			p1.TypicalAssignments.Add(a3);

			p2.TypicalAssignments.Add(a1);
			p2.TypicalAssignments.Add(a2);

			p3.TypicalAssignments.Add(a2);
			p3.TypicalAssignments.Add(a3);

			// ProjId	| 1 | 2 | 3 |
			//_____________________
			//	 1		| x | x | X |
			//	 2		| x | x |   |
			//	 3		|   | x | x |

			db.Projects.AddRange(new List<Project> { p1, p2, p3 });

			db.SaveChanges();
			db.Assignments.AddRange(assignments);
			db.SaveChanges();
		}


		[TestMethod]
		public void DbCreated()
		{
			//Assert
			Assert.IsNotNull(db);
			Assert.AreEqual(db.Users.Count(), users.Count());
			Assert.AreEqual(db.Projects.Count(), 3);
			Assert.AreEqual(db.TypicalAssignments.Count(), 3);
			Assert.AreEqual(db.Assignments.Count(), assignments.Count());
			Assert.AreEqual(db.Hours.Count(), 24);
			Assert.AreEqual(db.Minutes.Count(), 4);
		}

		[TestMethod]
		public void UowCreated()
		{
			//Assert
			Assert.IsNotNull(src);
			Assert.IsNotNull(src.Users);
			Assert.IsNotNull(src.Projects);
			Assert.IsNotNull(src.Hours);
			Assert.IsNotNull(src.Minutes);
			Assert.IsNotNull(src.TypicalAssignments);
			Assert.IsNotNull(src.Assignments);


		}
	}
	
}
