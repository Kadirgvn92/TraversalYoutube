using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Commands.GuideCommands;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.GuideHandlers;

public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
{
    private readonly Context _context;

    public CreateGuideCommandHandler(Context context)
    {
        _context = context;
    }

    public async Task Handle(CreateGuideCommand request, CancellationToken cancellationToken)
    {
        _context.Guides.Add(new Guide
        {
            Name = request.Name,
            Description = request.Description,
            Image = request.Image
        });
        await _context.SaveChangesAsync();
    }
}
