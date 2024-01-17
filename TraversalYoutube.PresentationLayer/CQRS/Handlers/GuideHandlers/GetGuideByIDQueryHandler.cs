using MediatR;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;
using TraversalYoutube.PresentationLayer.CQRS.Results.GuideResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.GuideHandlers;

public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
{
    private readonly Context _context;

    public GetGuideByIDQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Guides.FindAsync(request.Id);
        return new GetGuideByIDQueryResult
        {
            GuideID = values.GuideID,
            Description = values.Description,
            Name = values.Name
        };
    }


}
