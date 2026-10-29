using Blackhellheim.Application.Contracts;
using Blackhellheim.Infraestructure.Persistence;
using Blackhellheim.Infraestructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blackhellheim.Infraestructure;

public static class DependencyInyection
{
    public static IServiceCollection AgregaInfraestructura(this IServiceCollection services)
    {
        services.AddDbContext<BlackhellheimDbContext>(options =>
            options.UseSqlServer("DefaultConnection"));

        services.AddScoped<IRepositoriyProducts, RepositoryProducts>();

        return services;
    }
}
