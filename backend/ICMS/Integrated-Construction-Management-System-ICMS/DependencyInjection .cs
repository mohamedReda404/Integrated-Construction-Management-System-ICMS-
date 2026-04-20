
using Integrated_Construction_Management_System_ICMS.Authentication;
using Integrated_Construction_Management_System_ICMS.Services;

namespace Integrated_Construction_Management_System_ICMS
{
    public static class DepandancyInjection
    {
        

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddapplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

             services.AddScoped<IProjectService, ProjectService>();
             services.AddScoped<IBOQServices, BOQServices>();
             services.AddScoped<IBOQPricingServices, BOQPricingServices>();
             services.AddScoped<IDrawingService, DrawingService>();
             services.AddScoped<IInvoiceService, InvoiceService>();
             services.AddScoped<IInvoiceItemService, InvoiceItemService>();
             services.AddScoped<IProjectContractService, ProjectContractService>();
             services.AddScoped<IMaterialRequestServices, MaterialRequestServices>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<IJwtProvider, JwtProvider>();

            //services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.Key!)),
                    ValidIssuer = jwtSettings?.Issuer,
                    ValidAudience = jwtSettings?.Audience
                };
            });
            services.Configure<JwtOptions>(
            configuration.GetSection(JwtOptions.SectionName)
);


            services.AddCors(O => 
            O.AddDefaultPolicy(B => 
            B.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins(configuration
            .GetSection("AllowOrigin")
            .Get<string>()!)));
            
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
