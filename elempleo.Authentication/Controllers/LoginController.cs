using elempleo.Authentication.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace elempleo.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService loginService;

		public LoginController(ILoginService loginService)
		{
			this.loginService = loginService;
		}

		[HttpGet]
		public async Task<IActionResult> Login(string userName, string password)
		{
			return Ok(await this.loginService.LoginAsync(userName, password));
		}
	}
}
