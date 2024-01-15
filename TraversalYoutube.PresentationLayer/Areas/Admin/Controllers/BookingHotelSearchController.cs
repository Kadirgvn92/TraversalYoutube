using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class BookingHotelSearchController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2024-01-30&departure_date=2024-02-10&guest_qty=1&dest_ids=-740501&room_qty=1&search_type=city&children_qty=2&children_age=5%2C7&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure"),
            Headers =
    {
        { "X-RapidAPI-Key", "1b835557bamsh51f42a1ec11b465p131830jsn7e5d47c9227c" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var bodyReplace = body.Replace(".", "");
            var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
            return View(values.result);
        }
    }
}
