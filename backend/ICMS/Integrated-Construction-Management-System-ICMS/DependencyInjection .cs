using Integrated_Construction_Management_System_ICMS.Services.Classes;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS
{
    public static class DepandancyInjection
    {
        

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddapplicationServices(this IServiceCollection services)
        {
           // services.AddScoped<IProjectService, ProjectService>();
            return services;
        }


        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
