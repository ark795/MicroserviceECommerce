using Microsoft.EntityFrameworkCore;
using OrderService.API.Infrastructure.Persistence;

namespace OrderService.API.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("Postgres")));

            return services;
        }
    }
}
