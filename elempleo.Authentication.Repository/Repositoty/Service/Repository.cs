using elempleo.Authentication.Repository.Context;
using elempleo.Authentication.Repository.Repositoty.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace elempleo.Authentication.Repository.Repositoty.Service
{
	public class Repository<T> : IRepository<T> where T : Entity.Base.Entity
	{
		private readonly ContextDb contextDataBase;
		private readonly DbSet<T> entity;

		public Repository(ContextDb contextDataBase)
		{
			this.contextDataBase = contextDataBase;
			this.entity = this.contextDataBase.Set<T>();
		}

		public IEnumerable<T> All()
		{
			IQueryable<T> query = this.entity
				.AsNoTracking();

			return query.ToList();
		}

		public int ExecuteSp(string spName, List<SqlParameter> parameters)
		{
			var query = 0;
			if (parameters.Any())
			{
				spName = spName + " " + ConfigureParameterProcedure(parameters);
				query = this.contextDataBase.Database.ExecuteSqlRaw("exec " + spName, parameters);
			}
			else
				query = this.contextDataBase.Database.ExecuteSqlRaw("exec " + spName);

			return query;
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			return query.ToList();
		}

		public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return query.ToList();
		}

		public T SingleFindBy(Expression<Func<T, bool>> predicate)
		{
			return this.entity
				.SingleOrDefault(predicate);
		}

		private string ConfigureParameterProcedure(List<SqlParameter> parameters)
		{
			var chain = "";
			var count = parameters.Count();
			for (int i = 0; i < count; i++)
			{
				if (i == count - 1)
					chain = chain + parameters[i].ParameterName;
				else
					chain = chain + parameters[i].ParameterName + ",";
			}
			return chain;
		}

	}
}
