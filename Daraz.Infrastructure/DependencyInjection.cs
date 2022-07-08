using Daraz.Application.Common.Interfaces;
using Daraz.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daraz.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<DarazDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
            x => x.MigrationsAssembly("Daraz.Api"));
        });
        return services;
    }
}
