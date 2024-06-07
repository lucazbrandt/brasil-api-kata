using BrasilApiKata.Domain.Holidays.Models;
using BrasilKata.Application.Holidays.Queries;
using BrasilKata.Application.Holidays.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrasilKata.Application.Holidays.Handlers;

public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQuery, List<Holiday>>
{
    private readonly IHolidayService _holidayService;
    private readonly ILogger<GetHolidaysQueryHandler> _logger;

    public GetHolidaysQueryHandler(IHolidayService holidayService, ILogger<GetHolidaysQueryHandler> logger)
    {
        _logger = logger;
        _holidayService = holidayService;
    }

    public async Task<List<Holiday>> Handle(GetHolidaysQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching holidays to year {Year}", query.Year);

        var holidays = await _holidayService.GetHolidays(query.Year);

        _logger.LogInformation("{Year} has {Size} holidays!", query.Year, holidays.Count);

        return holidays;
    }
}