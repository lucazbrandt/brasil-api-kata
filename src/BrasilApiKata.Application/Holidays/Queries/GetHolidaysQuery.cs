using BrasilApiKata.Domain.Holidays.Models;
using MediatR;

namespace BrasilKata.Application.Holidays.Queries;

public class GetHolidaysQuery: IRequest<List<Holiday>> {
    public int Year {get; set;}
}