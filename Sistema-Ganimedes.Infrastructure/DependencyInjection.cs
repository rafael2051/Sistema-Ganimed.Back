using Microsoft.Extensions.DependencyInjection;
using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Sistema_Ganimedes.Infrastructure.Repository;

namespace Sistema_Ganimedes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IFormularioRepository, FormularioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
            services.AddScoped<IParecerRepository, ParecerRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddSingleton(provider =>
            {
                var host = Environment.GetEnvironmentVariable("HOST");
                var db = Environment.GetEnvironmentVariable("DB");
                var user = Environment.GetEnvironmentVariable("USERNAME");
                var pswd = Environment.GetEnvironmentVariable("PASSWORD");

                var connectionString = $"Host={host};Database={db};Username={user};Password={pswd}";

                return new DbContext(connectionString);
            });

            return services;
        }
    }
}
