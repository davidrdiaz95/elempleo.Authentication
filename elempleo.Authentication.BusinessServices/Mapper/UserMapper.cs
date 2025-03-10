using elempleo.Authentication.Model.Dto;
using elempleo.Authentication.Repository.Entity;

namespace elempleo.Authentication.BusinessServices.Mapper
{
	public static class UserMapper
	{
		public static UserDto MapFrom(this UserEntity model)
		{
			var user = new UserDto
			{
				Id = model.Id,
				FullName = model.FullName,
				UserName = model.UserName,
				IdRol = model.IdRol,
				Rol = model.Rol.MapFrom()
			};
			return user;
		}

		public static UserEntity MapTo(this UserDto model)
		{
			var user = new UserEntity
			{
				Id = model.Id,
				FullName = model.FullName,
				UserName = model.UserName,
				IdRol = model.IdRol
			};
			return user;
		}

		public static UserDto MapFirstFrom(this IEnumerable<UserEntity> model)
		{
			var user = new UserDto
			{
				Id = model.First().Id,
				FullName = model.First().FullName,
				UserName = model.First().UserName,
				Password = model.First().Password,
				IdRol = model.First().IdRol,
				Rol = model.First().Rol.MapFrom()
			};
			return user;
		}
	}
}
