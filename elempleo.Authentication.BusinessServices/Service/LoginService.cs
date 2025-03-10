using elempleo.Authentication.Model.Dto;
using elempleo.Authentication.Services.Invoker;
using elempleo.Authentication.Services.Service;

namespace elempleo.Authentication.BusinessServices.Service
{
	public class LoginService : ILoginService
	{
		private readonly IGenerateTokenInvoker generateTokenInvoker;

		public LoginService(IGenerateTokenInvoker generateTokenInvoker)
		{
			this.generateTokenInvoker = generateTokenInvoker;
		}

		public async Task<ResponseDTO<string>> LoginAsync(string userName, string password)
		{
			return await this.generateTokenInvoker.Execute(userName, password);
		}
	}
}
