using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class ApiExchangeController : Controller
{
    public async Task<IActionResult> Index()
    {
        List<BookingExchangeViewModel> booking = new List<BookingExchangeViewModel>(); 
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=TRY&languagecode=en-us"),
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
            var values = JsonConvert.DeserializeObject<BookingExchangeViewModel>(body);
            return View(values.exchange_rates);
        }
    }
}
