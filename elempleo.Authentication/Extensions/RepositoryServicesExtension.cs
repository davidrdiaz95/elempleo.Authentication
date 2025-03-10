using elempleo.Authentication.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace elempleo.Authentication.Extensions
{
	public static class RepositoryServicesExtension
	{
		public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ContextDb>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
