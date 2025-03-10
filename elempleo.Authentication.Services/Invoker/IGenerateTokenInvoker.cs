using elempleo.Authentication.Model.Dto;

namespace elempleo.Authentication.Services.Invoker
{
	public interface IGenerateTokenInvoker
	{
		Task<ResponseDTO<string>> Execute(string userName, string password);
	}
}
