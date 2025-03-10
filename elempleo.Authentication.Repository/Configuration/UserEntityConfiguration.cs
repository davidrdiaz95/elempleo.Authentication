using elempleo.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.Authentication.Repository.Configuration
{
	public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable("Users");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.FullName).HasColumnName("full_name");
			builder.Property(x => x.UserName).HasColumnName("user_name");
			builder.Property(x => x.Password).HasColumnName("password");
			builder.Property(x => x.IsActive).HasColumnName("is_active");
			builder.Property(x => x.IdRol).HasColumnName("fk_id_rol");
			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");
			builder.HasOne(x=> x.Rol).WithMany(x=> x.Users).HasForeignKey(x => x.IdRol);
		}
	}
}
