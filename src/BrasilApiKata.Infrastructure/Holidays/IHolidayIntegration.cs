using Refit;

namespace BrasilApiKata.Infrastructure.Holidays;

public interface IHolidayIntegration
{
    [Get("/feriados/v1/{year}")]
    Task<List<HolidayResponse>> GetHolidays(int year);
}