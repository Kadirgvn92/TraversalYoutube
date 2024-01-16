﻿namespace TraversalYoutube.PresentationLayer.CQRS.Commands.DestinationCommands;

public class CreateDestinationCommand
{
    public string? City { get; set; }
    public string? DayNight { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public int Capacity { get; set; }
    public bool Status { get; set; }
}
