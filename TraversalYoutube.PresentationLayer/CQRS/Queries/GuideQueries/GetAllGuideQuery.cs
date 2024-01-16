using MediatR;
using TraversalYoutube.PresentationLayer.CQRS.Results.GuideResults;

namespace TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;

public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
{
}
