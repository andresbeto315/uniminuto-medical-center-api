using Domain.Base;
using Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            Config config = Config.Instance;
            services.AddDbContext<MedicalCenterDbContext>(options =>
                options.UseMySQL(config.ConnectionString));

            services
                // Repositories
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserTypeRepository, UserTypeRepository>()
                .AddTransient<IStateRepository, StateRepository>()
                .AddTransient<IMedicalAppointmentRepository, MedicalAppointmentRepository>();

            return services;
        }
    }
}