using System;
using TaskPlanner.DAL.Entities;

namespace TaskPlanner.DAL.Interfaces
{

	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Зарегистрированные пользователи
		/// </summary>
		IRepository<User> Users { get; }

		/// <summary>
		/// Реестр проектов
		/// </summary>
		IRepository<Project> Projects { get; }

		/// <summary>
		/// Реестр типовых задач
		/// </summary>
		IRepository<TypicalAssignment> TypicalAssignments { get; }

		/// <summary>
		/// Реестр задач
		/// </summary>
		IRepository<Assignment> Assignments { get; }

		/// <summary>
		/// Справочник часов
		/// </summary>
		IRepository<Hour> Hours { get; }

		/// <summary>
		/// Справочник минут
		/// </summary>
		IRepository<Minute> Minutes { get; }

		/// <summary>
		/// Фонд рабочего времени
		/// </summary>
		IRepository<WTF> WTFs { get; }
	}
}
