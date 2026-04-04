

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

             services.AddScoped<IProjectService, ProjectService>();
            //services.AddScoped<IProj, ProjectContractService>();
            //services.AddScoped<IAuthServices, AuthServices>();
            services.AddSingleton<JwtProvider>();
            return services;
        }


        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }


        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
