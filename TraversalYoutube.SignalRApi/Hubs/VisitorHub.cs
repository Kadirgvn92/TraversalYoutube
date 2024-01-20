using Microsoft.AspNetCore.SignalR;
using TraversalYoutube.SignalRApi.Model;

namespace TraversalYoutube.SignalRApi.Hubs;

public class VisitorHub : Hub
{
    private readonly VisitorService _visitorService;

    public VisitorHub(VisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    public async Task GetVisitorList()
    {
        await Clients.All.SendAsync("GetVisitList", _visitorService.GetVisitorChartList());
    }
}
