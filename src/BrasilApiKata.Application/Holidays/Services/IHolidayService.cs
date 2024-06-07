using BrasilApiKata.Domain.Holidays.Models;

namespace BrasilKata.Application.Holidays.Services;

public interface IHolidayService
{
    Task<List<Holiday>> GetHolidays(int year);
}