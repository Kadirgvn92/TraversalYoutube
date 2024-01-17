using MediatR;
using TraversalYoutube.PresentationLayer.CQRS.Results.GuideResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;

public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
{
    public GetGuideByIDQuery(int ıd)
    {
        Id = ıd;
    }

    public int Id { get; set; }
}
