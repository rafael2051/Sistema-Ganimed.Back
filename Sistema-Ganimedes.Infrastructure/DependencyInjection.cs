using Microsoft.Extensions.DependencyInjection;
using Sistema_Ganimedes.Infrastructure;
using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Sistema_Ganimedes.Infrastructure.Repository;
using Sistema_Ganimedes.Infrastructure.Repository.Interfaces;

namespace Sistema_Ganimedes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IFormularioRepository, FormularioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
            services.AddScoped<IParecerRepository, ParecerRepository>();

            services.AddSingleton<DbContext>();

            return services;
        }
    }
}
