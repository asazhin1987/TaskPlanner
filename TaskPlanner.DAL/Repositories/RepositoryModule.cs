
using TaskPlanner.DAL.EF;
using TaskPlanner.DAL.Entities;


namespace TaskPlanner.DAL.Repositories
{
	public class UserRepository : Repository<User>
	{
		public UserRepository(TaskPlannerContext context) : base(context) { }
	}

	public class ProjectRepository : Repository<Project>
	{
		public ProjectRepository(TaskPlannerContext context) : base(context) { }
	}

	public class TypicalAssignmentRepository : Repository<TypicalAssignment>
	{
		public TypicalAssignmentRepository(TaskPlannerContext context) : base(context) { }
	}

	public class AssignmentRepository : Repository<Assignment>
	{
		public AssignmentRepository(TaskPlannerContext context) : base(context) { }
	}

	public class HourRepository : Repository<Hour>
	{
		public HourRepository(TaskPlannerContext context) : base(context) { }
	}

	public class MinuteRepository : Repository<Minute>
	{
		public MinuteRepository(TaskPlannerContext context) : base(context) { }
	}

	public class WTFRepository : Repository<WTF>
	{
		public WTFRepository(TaskPlannerContext context) : base(context) { }
	}

}
