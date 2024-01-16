

using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Queries.DestinationQueries;
using TraversalYoutube.PresentationLayer.CQRS.Results.DestinationResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;

public class GetDestinationByIDQueryHandler
{
    private readonly Context _context;

    public GetDestinationByIDQueryHandler(Context context)
    {
        _context = context;
    }

    public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
    {
        var values = _context.Destinations.Find(query.id);
        return new GetDestinationByIDQueryResult
        {
            id = values.DestinationID,
            city = values.City,
            daynight = values.DayNight,
            price = values.Price
        };
    } 
}
