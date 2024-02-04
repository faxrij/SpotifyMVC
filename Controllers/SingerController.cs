using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SingerController : ControllerBase
{
    private readonly ISingerService _singerService;

    public SingerController(ISingerService singerService)
    {
        _singerService = singerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Singer>>> GetSingers()
    {
        var singers = await _singerService.GetAllSingersAsync();
        return Ok(singers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Singer>> GetSinger(int id)
    {
        var singer = await _singerService.GetSingerByIdAsync(id);

        if (singer == null)
        {
            return NotFound();
        }

        return Ok(singer);
    }

    [HttpPost]
    public async Task<ActionResult<Singer>> CreateSinger(CreateSingerRequest createSingerRequest)
    {
        var createdSinger = await _singerService.CreateSingerAsync(createSingerRequest);
        return CreatedAtAction(nameof(GetSinger), new { id = createdSinger.Id }, createdSinger);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSinger(int id)
    {
        var result = await _singerService.RemoveSingerAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
}