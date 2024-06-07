using BrasilApiKata.Infrastructure.Holidays;
using BrasilKata.Application.Holidays.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrasilApiKata.Infrastructure.Commons;

public static class BrasilApiExtension
{
    public static IServiceCollection AddBrasilApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<BrasilApiConfig>(opts => configuration.GetSection(BrasilApiConfig.BrasilApi).Bind(opts));
        services.AddScoped<IHolidayService, HolidayService>();

        return services;
    }
}