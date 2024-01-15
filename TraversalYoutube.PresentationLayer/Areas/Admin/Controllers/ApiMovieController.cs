using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class ApiMovieController : Controller
{
    public async Task<IActionResult> Index()
    {
        List<ApiMovieViewModel> model = new List<ApiMovieViewModel>();
        
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
    {
        { "X-RapidAPI-Key", "1b835557bamsh51f42a1ec11b465p131830jsn7e5d47c9227c" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            return View(values);
        }
    }
}
