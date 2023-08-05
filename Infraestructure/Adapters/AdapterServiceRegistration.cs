using Domain.Contracts.Adapter.IMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Adapters
{
    public static class AdapterServiceRegistration
    {
        public static IServiceCollection AddAdapterServices(this IServiceCollection services)
        {
            //Lines for example
            services.AddTransient<IMapper, Mapper.Mapper>();
            return services;
        }
    }
}