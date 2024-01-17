using MediatR;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Commands.GuideCommands;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.GuideHandlers;

public class DeleteGuideCommandHandler : IRequestHandler<DeleteGuideCommand>
{
    private readonly Context _context;

    public DeleteGuideCommandHandler(Context context)
    {
        _context = context;
    }

    public async Task Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
    {
        var values = await _context.Guides.FindAsync(request.id);
        _context.Guides.Remove(values);
        _context.SaveChanges();
    }
}
