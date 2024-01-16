
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;
using TraversalYoutube.PresentationLayer.CQRS.Results.GuideResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.GuideHandlers;

public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
{
    private readonly Context _context;

    public GetAllGuideQueryHandler(Context context)
    {
        _context = context;
    }

    async Task<List<GetAllGuideQueryResult>> IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>.Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
    {
        return await _context.Guides.Select(x => new GetAllGuideQueryResult
        {
            GuideID = x.GuideID,
            Name = x.Name,
            Description = x.Description,
            Image = x.Image 
        }).AsNoTracking().ToListAsync();
    }
}
