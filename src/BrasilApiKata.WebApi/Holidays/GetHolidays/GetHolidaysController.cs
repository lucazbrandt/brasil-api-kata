using System.ComponentModel.DataAnnotations;
using BrasilKata.Application.Holidays.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiKata.WebApi.Holidays.GetHolidays;

[ApiController]
[Route("holidays")]
public class GetHolidaysController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<GetHolidaysController> _logger;

    public GetHolidaysController(IMediator mediator, ILogger<GetHolidaysController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{year:int}", Name = "GetHolidays")]

    public async Task<List<GetHolidaysResponse>> Get([FromRoute][Required] int year)
    {
        GetHolidaysQuery query = new GetHolidaysQuery
        {
            Year = year
        };

        var result = await _mediator.Send(query);

        return result.Select(model =>
            new GetHolidaysResponse
            {
                Date = model.Date,
                Name = model.Name,
            }
        ).ToList();
    }
}