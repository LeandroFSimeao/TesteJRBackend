using apiToDo.Repository;
using apiToDo.Repository.Interface;
using apiToDo.Services;
using apiToDo.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace apiToDo.DI
{
    public static class RegistrationDependencyInjectionExtensions
    {
        //Configuração da injeção de dependência do repository e service utilizando o parâmetro IServiceCollection
        public static void AddRegistrationDependencies(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITarefasRepository, TarefasRepository>();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITarefasService, TarefasService>();
        }

    }
}
