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
           
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IBoqCondtionConsultantService, BoqCondtionConsultantService>();
            services.AddScoped<IBoqCondtionEngService, BoqCondtionEngService>();
            services.AddScoped<IConsultantBoqService, ConsultantBoqService>();
            services.AddScoped<IEngineerBoqService, EngineerBoqService>();
            services.AddScoped<IEngineerInvoiceService, EngineerInvoiceService>();
            services.AddScoped<IForemanService, ForemanService>();
            services.AddScoped<IFormanTasksService, FormanTasksService>();
            services.AddScoped<IGeneralDrowingService, GeneralDrowingService>();
            services.AddScoped<IMainClientService, MainClientService>();
            services.AddScoped<IMainConsultantService, MainConsultantService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IProjectContractService, ProjectContractService>();
            services.AddScoped<IProjectManagerService, ProjectManagerService>();
            services.AddScoped<IProjectSiteEngineerService, ProjectSiteEngineerService>();
            services.AddScoped<IProjectSubConsultantService, ProjectSubConsultantService>();
            services.AddScoped<IProjectSubContractorService, ProjectSubContractorService>();
            services.AddScoped<IShopDrawingService, ShopDrawingService>();
            services.AddScoped<ISiteEngineerService, SiteEngineerService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISubConstractorInvoiceService, SubConstractorInvoiceService>();
            services.AddScoped<ISubConsultantService, SubConsultantService>();
            services.AddScoped<ISubContractorService, SubContractorService>();
           
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
