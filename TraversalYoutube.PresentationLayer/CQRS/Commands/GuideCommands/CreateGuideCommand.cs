using MediatR;

namespace TraversalYoutube.PresentationLayer.CQRS.Commands.GuideCommands;

public class CreateGuideCommand : IRequest
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}
