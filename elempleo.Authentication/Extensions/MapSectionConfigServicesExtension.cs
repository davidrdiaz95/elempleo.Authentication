using elempleo.Authentication.Model.Section;

namespace elempleo.Authentication.Extensions
{
	public static class MapSectionConfigServicesExtension
	{
		public static void ConfigureMapSectionConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configuracionTokenConfiguration = configuration.GetSection("TokenConfiguration");
			services.Configure<TokenConfiguration>(configuracionTokenConfiguration);

			IConfigurationSection configuracionEncrypt = configuration.GetSection("Encrypt");
			services.Configure<EncryptSection>(configuracionEncrypt);
		}
	}
}
