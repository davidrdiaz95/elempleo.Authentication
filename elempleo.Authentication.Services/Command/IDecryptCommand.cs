namespace elempleo.Authentication.Services.Command
{
	public interface IDecryptCommand
	{
		Task<string> Execute(string cipherText);
	}
}
