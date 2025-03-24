using ICI_NoticiasMVC.Application.Mapping;
using ICI_NoticiasMVC.Application.Services;
using ICI_NoticiasMVC.Core.Interfaces;
using ICI_NoticiasMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ICI_NoticiasMVC.Infrastructure.Configuration
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDependencyDatabase(services, configuration);

            services.AddScoped<INoticiaService, NoticiaService>();

            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        private static void AddDependencyDatabase(IServiceCollection services, IConfiguration configuration) 
        {
            // AppDbContext com SQLite
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
