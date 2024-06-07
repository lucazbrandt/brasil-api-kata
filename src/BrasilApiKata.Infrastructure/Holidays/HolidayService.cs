using BrasilApiKata.Domain.Holidays.Models;
using BrasilApiKata.Infrastructure.Commons;
using BrasilKata.Application.Holidays.Services;
using Microsoft.Extensions.Options;
using Refit;

namespace BrasilApiKata.Infrastructure.Holidays;

public class HolidayService : IHolidayService
{
    private readonly BrasilApiConfig config;

    public HolidayService(IOptions<BrasilApiConfig> options)
    {
        config = options.Value;
    }
    public async Task<List<Holiday>> GetHolidays(int year)
    {
        var holidayIntegration = RestService.For<IHolidayIntegration>(config.BaseUrl);

        var holidays = await holidayIntegration.GetHolidays(year);

        return holidays
            .Select(holiday =>
                new Holiday(holiday.Date, holiday.Name, holiday.Type))
            .ToList();
    }
}