using Logcast.Recruitment.Domain.Services;
using Logcast.Recruitment.Domain.Services.Audio;
using Logcast.Recruitment.Domain.Services.FileStorage;
using Logcast.Recruitment.Domain.Services.Subscription;
using Microsoft.Extensions.DependencyInjection;

namespace Logcast.Recruitment.Domain.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IAudioService, AudioService>();
            services.AddSingleton<IFileStorageService, InMemoryFileStorageService>();
        }
    }
}