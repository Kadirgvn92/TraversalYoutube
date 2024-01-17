using MediatR;

namespace TraversalYoutube.PresentationLayer.CQRS.Commands.GuideCommands;

public class DeleteGuideCommand :IRequest
{
    public DeleteGuideCommand(int id)
    {
        this.id = id;
    }

    public int id { get; set; }
}
