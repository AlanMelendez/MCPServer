using MCPServer.Interfaces;
using MCPServer.Services;
using System.Net.NetworkInformation;

namespace MCPServer.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddSingleton<IPeopleRepository, PeopleRepositoryInMemory>();
            return services;
        }
    }
}
