using Microsoft.AspNetCore.Mvc;
namespace ASPNet.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    // GET
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        string[] studentNames = new string[] { "Alfredo", "Carolina", "Marcely" };
        return Ok(studentNames);
    }
}