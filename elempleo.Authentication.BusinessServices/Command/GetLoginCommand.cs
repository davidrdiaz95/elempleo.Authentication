using elempleo.Authentication.BusinessServices.Mapper;
using elempleo.Authentication.Model.Dto;
using elempleo.Authentication.Repository.Entity;
using elempleo.Authentication.Repository.Repositoty.Interface;
using elempleo.Authentication.Services.Command;

namespace elempleo.Authentication.BusinessServices.Command
{
	public class GetLoginCommand : IGetLoginCommand
	{
		private readonly IRepository<UserEntity> repository;

		public GetLoginCommand(IRepository<UserEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<UserDto?> Execute(string userName, string password)
		{
			var login = this.repository.FindByInclude(x => x.UserName.Equals(userName), i => i.Rol);
			return login?.MapFirstFrom();
		}
	}
}
