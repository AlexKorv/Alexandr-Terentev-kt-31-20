using terentevalexandrKt_31_20.Interfaces.WorkloadInterfaces;

namespace terentevalexandrKt_31_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkloadService, WorkloadService>();

            return services;
        }
    }
}
