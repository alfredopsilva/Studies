using Microsoft.AspNetCore.Mvc;

namespace ASPNet.UI.Controllers;

public class RegionsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegionsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        //
        try
        {
            var client = _httpClientFactory.CreateClient();
            var httpResponseMessage = await client.GetAsync("http://localhost:5017/api/Regions");
            httpResponseMessage.EnsureSuccessStatusCode();
            var stringResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            ViewBag.Response = stringResponse; 

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return View();
    }
}