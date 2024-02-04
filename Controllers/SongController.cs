using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSongs()
    {
        try
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSongById(int id)
    {
        try
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song == null)
            {
                return NotFound(); // Song with given id not found
            }

            return Ok(song);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSong(CreateSongRequest createSongRequest)
    {
        try
        {
            var createdSong = await _songService.CreateSongAsync(createSongRequest);
            return CreatedAtAction(nameof(GetSongById), new { id = createdSong.SongId }, createdSong);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveSong(int id)
    {
        try
        {
            var isRemoved = await _songService.RemoveSongAsync(id);

            if (!isRemoved)
            {
                return NotFound(); // Song with given id not found
            }

            return NoContent(); // Successfully removed
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}