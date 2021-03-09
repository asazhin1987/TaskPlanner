using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.DAL.EF;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TaskPlanner.DAL.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly TaskPlannerContext db;
		protected DbSet<T> dbSet;
		public Repository(TaskPlannerContext context)
		{
			db = context;
			dbSet = context.Set<T>();
		}

		public virtual IQueryable<T> GetAll()
		{
			return dbSet.AsQueryable();
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public virtual async Task<T> GetAsync(int id)
		{
			try
			{
				return await dbSet.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public virtual async Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
		{
			return await Include(includeProperties).ToListAsync();
		}

		public virtual IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = Include(includeProperties);
			return query.Where(predicate).ToList();
		}

		public virtual IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = dbSet.AsNoTracking();
			return includeProperties
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		public virtual async Task CreateAsync(T item)
		{
			dbSet.Add(item);
			await db.SaveChangesAsync();
		}

		
		public virtual async Task DeleteAsync(int id)
		{
			try
			{
				T item = await dbSet.FindAsync(id);
				if (item != null)
					await DeleteAsync(item);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task DeleteAsync(T item)
		{
			try
			{
				dbSet.Remove(item);
				await db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public virtual IEnumerable<T> Find(Func<T, bool> predicate)
		{
			return dbSet.AsNoTracking().Where(predicate).ToList();
		}

		public virtual T Get(int Id)
		{
			return dbSet.Find(Id);
		}

		public virtual async Task UpdateAsync(T item)
		{
			db.Entry(item).State = EntityState.Modified;
			await db.SaveChangesAsync();
		}

		public virtual T Get(string Key)
		{
			return dbSet.Find(Key);
		}


	}
}
