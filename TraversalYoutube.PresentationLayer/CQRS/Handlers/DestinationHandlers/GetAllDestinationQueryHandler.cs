using Microsoft.EntityFrameworkCore;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Queries.DestinationQueries;
using TraversalYoutube.PresentationLayer.CQRS.Results.DestinationResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;

public class GetAllDestinationQueryHandler
{
    private readonly Context _context;

    public GetAllDestinationQueryHandler(Context context)
    {
        _context = context;
    }

    public List<GetAllDestinationQueryResult> Handle()
    {
        var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
        {
            id = x.DestinationID,
            daynight = x.DayNight,
            city = x.City,
            capacity = x.Capacity,
            price = x.Price
        }).AsNoTracking().ToList();
        return values;
    }
}
