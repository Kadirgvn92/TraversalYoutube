using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Commands.DestinationCommands;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;

public class DeleteDestinationCommandHandler
{
    private readonly Context _context;

    public DeleteDestinationCommandHandler(Context context)
    {
        _context = context;
    }

    public void Handle(DeleteDestinationCommand command)
    {
        var values = _context.Destinations.Find(command.id);
        _context.Destinations.Remove(values);
        _context.SaveChanges();
    }
}
