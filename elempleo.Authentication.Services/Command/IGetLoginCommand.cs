using elempleo.Authentication.Model.Dto;

namespace elempleo.Authentication.Services.Command
{
    public interface IGetLoginCommand
    {
		Task<UserDto?> Execute(string userName, string password);
	}
}
