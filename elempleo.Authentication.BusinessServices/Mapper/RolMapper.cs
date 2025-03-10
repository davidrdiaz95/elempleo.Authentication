using elempleo.Authentication.Model.Dto;
using elempleo.Authentication.Repository.Entity;

namespace elempleo.Authentication.BusinessServices.Mapper
{
    public static class RolMapper
    {
		public static RolDto MapFrom(this RolUserEntity model)
		{
			var rol = new RolDto
			{
				Id = model.Id,
				Name = model.Name,
			};
			return rol;
		}

		public static RolUserEntity MapTo(this RolDto model)
		{
			var rol = new RolUserEntity
			{
				Id = model.Id,
				Name = model.Name,
			};
			return rol;
		}
	}
}
