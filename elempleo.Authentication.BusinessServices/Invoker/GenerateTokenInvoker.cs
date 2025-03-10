using elempleo.Authentication.Model.Dto;
using elempleo.Authentication.Model.Section;
using elempleo.Authentication.Model.Util;
using elempleo.Authentication.Services.Command;
using elempleo.Authentication.Services.Invoker;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace elempleo.Authentication.BusinessServices.Invoker
{
	public class GenerateTokenInvoker : IGenerateTokenInvoker
	{
		private readonly TokenConfiguration tokenConfiguration;
		private readonly IGetLoginCommand getLoginCommand;
		private readonly IDecryptCommand decryptCommand;

		public GenerateTokenInvoker(IOptions<TokenConfiguration> options,
			IGetLoginCommand getLoginCommand,
			IDecryptCommand decryptCommand)
		{
			tokenConfiguration = options.Value;
			this.getLoginCommand = getLoginCommand;
			this.decryptCommand = decryptCommand;
		}

		public async Task<ResponseDTO<string>> Execute(string userName, string password)
		{
			var user = await getLoginCommand.Execute(userName, password);
			if (user == null)
				return ResponseStatus.ResponseWithoutData<string>("No se encontro el usuario");

			var passwordUser = await this.decryptCommand.Execute(user.Password);
			if (passwordUser != password)
				return ResponseStatus.ResponseWithoutData<string>("Usuario y contraseña no coincidence");

			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Role, user.Rol.Name));
			claims.Add(new Claim("idCustomer", user.Id.ToString()));

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secrect));
			SigningCredentials creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
			JwtSecurityToken token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(tokenConfiguration.ExpirationTime),
				signingCredentials: creds);

			return token != null ?
				ResponseStatus.ResponseSucessful<string>(new JwtSecurityTokenHandler().WriteToken(token)) :
				ResponseStatus.ResponseWithoutData<string>("No se encontro el usuario");
		}
	}
}
