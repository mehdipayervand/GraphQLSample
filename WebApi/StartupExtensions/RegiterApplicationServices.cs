using Domain;
using Domain.Data;
using Infrastructure;
using Infrastructure.Data;

namespace WebApi.StartupExtensions;

public static class RegisterApplicationServices
{
    public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IOrderRepository, OrderRepository>();
        services.AddSingleton<ICustomerRepository, CustomerRepository>();


    }
}