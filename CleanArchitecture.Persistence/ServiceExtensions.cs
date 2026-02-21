using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceExtensions
{
       public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
       {
              var connectionString = configuration.GetConnectionString("DefaultConnection");
              services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

              services.AddScoped<IUnitOfWork, UnitOfWork>();
              services.AddScoped<IUserRepository, UserRepository>();
       }
}