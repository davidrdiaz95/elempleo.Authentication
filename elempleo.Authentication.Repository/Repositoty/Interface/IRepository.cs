using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace elempleo.Authentication.Repository.Repositoty.Interface
{
	public interface IRepository<T>
	{
		T SingleFindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> All();
		IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
		int ExecuteSp(string spName, List<SqlParameter> parameters);
	}
}
