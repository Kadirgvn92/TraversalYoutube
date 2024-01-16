#nullable disable

namespace TraversalYoutube.PresentationLayer.CQRS.Commands.DestinationCommands;

public class UpdateDestinationCommand
{
    public int id { get; set; }
    public string city { get; set; }
    public string daynight { get; set; }
    public double price { get; set; }
}
