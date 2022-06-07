using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AktifBankCaseStudy.Infrastructure.EfCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureEFCore(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AktifBankDbContext>(options => {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}