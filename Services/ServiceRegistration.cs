using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using master_bppm.Models;
using master_bppm.Services;
using System.Reflection;
using master_bppm.Interfaces;
using master_bppm.Repository;
using master_bppm.Services;

namespace master_bppm.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services, IConfiguration configuration, string environmentName)
        {
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*", "*")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //MasterSparepartInventory
            services.AddScoped<IMasterBPPMServices, MasterBPPMServices>();
            services.AddScoped<IMasterBPPM, MasterBPPM>();
            return services;
        }
    }
}
