using elempleo.Authentication.Repository.Configuration;
using elempleo.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace elempleo.Authentication.Repository.Context
{
	public class ContextDb : DbContext
	{
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<RolUserEntity> RolUser { get; set; }

		public ContextDb(DbContextOptions options) : base(options)
		{
		}

		public ContextDb()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
			modelBuilder.ApplyConfiguration(new RolUserEntityConfiguration());
		}
	}
}
