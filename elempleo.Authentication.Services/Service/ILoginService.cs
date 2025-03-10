using elempleo.Authentication.Model.Dto;

namespace elempleo.Authentication.Services.Service
{
	public interface ILoginService
	{
		Task<ResponseDTO<string>> LoginAsync(string userName, string password);
	}
}
