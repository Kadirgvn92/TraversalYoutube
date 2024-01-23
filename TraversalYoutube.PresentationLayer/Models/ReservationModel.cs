using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Models;

public class ReservationModel
{
    public string Name { get; set; }
    public string PersonCount { get; set; }
    public DateTime ReservationDate { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string PhoneNumber { get; set; }
    public string Mail { get; set; }
    public string Destination { get; set; }
}
