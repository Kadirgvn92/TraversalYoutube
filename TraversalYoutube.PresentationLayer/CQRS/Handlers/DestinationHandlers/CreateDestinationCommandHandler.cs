using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Commands.DestinationCommands;

namespace TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;

public class CreateDestinationCommandHandler
{
    private readonly Context _context;

    public CreateDestinationCommandHandler(Context context)
    {
        _context = context;
    }

    public void Handle(CreateDestinationCommand command)
    {
        _context.Destinations.Add(new Destination
        {
            City = command.City,
            DayNight = command.DayNight,
            Price = command.Price,
            Capacity = command.Capacity,
            Status = true
        });
        _context.SaveChanges();
    }
}
