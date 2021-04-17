
namespace TaskPlanner.DAL.Entities
{
	public class ProjectAssignmentRelation
	{

		public int ProjectId { get; set; }

		public Project Project { get; set; }

		public int TypicalAssignmentId { get; set; }

		public TypicalAssignment TypicalAssignment { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
