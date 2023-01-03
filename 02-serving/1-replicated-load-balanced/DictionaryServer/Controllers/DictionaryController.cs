using DictionaryServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryServer.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController : ControllerBase
{
    private readonly DictionaryProvider provider;

    public DictionaryController(DictionaryProvider provider)
    {
        this.provider = provider;
    }
    [HttpGet("{key}")]
    public IActionResult Get(string key)
    {
        var value = this.provider.GetValue(key);
        if (value == null) return NotFound();
        return Ok(value);
    }
}
