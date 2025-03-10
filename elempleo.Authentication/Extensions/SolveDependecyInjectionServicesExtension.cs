using elempleo.Authentication.Repository.Repositoty.Interface;
using elempleo.Authentication.Repository.Repositoty.Service;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace elempleo.Authentication.Extensions
{
	public static class SolveDependecyInjectionServicesExtension
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			//services.AddScoped(typeof(IMapper<InvoiceProductDTO, InvoiceProductType>), typeof(InvoiceProductMapper));
			//services.AddScoped(typeof(IMapper<ProductDTO, Repository.Entity.Product>), typeof(ProductMapper));

			Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("elempleo.Authentication.Services");
			Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("elempleo.Authentication.BusinessServices");
			Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("elempleo.Authentication.Repository");

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Command"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Invoker"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Service"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Mapper"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDataInterface })
				.Where(c => c.Name.Contains("QueryObject"))
				.AsPublicImplementedInterfaces();

		}
	}
}
