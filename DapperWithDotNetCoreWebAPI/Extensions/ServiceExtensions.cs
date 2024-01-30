using DapperWithDotNetCoreWebAPI.Contract;
using DapperWithDotNetCoreWebAPI.Service;

namespace DapperWithDotNetCoreWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
