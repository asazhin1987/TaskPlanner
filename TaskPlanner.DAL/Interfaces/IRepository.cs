using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.DAL.Interfaces
{
	public interface IRepository<T>
	{
		Task<IEnumerable<T>> GetAllAsync();
		IQueryable<T> GetAll();
		Task<T> GetAsync(int id);
		T Get(int Id);
		Task CreateAsync(T item);
		Task UpdateAsync(T item);
		Task DeleteAsync(int id);
		Task DeleteAsync(T item);

		Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
		IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
		IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
	}
}
