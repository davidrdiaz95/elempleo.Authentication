using elempleo.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.Authentication.Repository.Configuration
{
	public class RolUserEntityConfiguration : IEntityTypeConfiguration<RolUserEntity>
	{
		public void Configure(EntityTypeBuilder<RolUserEntity> builder)
		{
			builder.ToTable("RolUser");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.Name).HasColumnName("name_rol");
			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");
		}
	}
}
