using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsalesBackEnd.Constants;
using PruebaTecnicaCarsalesBackEnd.Models;
using PruebaTecnicaCarsalesBackEnd.Services;

namespace PruebaTecnicaCarsalesBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EpisodesController : ControllerBase
{
    private readonly RickAndMortyService _service;
    private readonly ILogger<EpisodesController> _logger;

    public EpisodesController(RickAndMortyService service, ILogger<EpisodesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<EpisodesResponse>> GetEpisodes(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        [FromQuery] string? episode = null)
    {
        try
        {
            _logger.LogInformation(
                MessagesConstants.GetEpisodesLog,
                page, name, episode);

            var result = await _service.GetEpisodesAsync(page, name, episode);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, MessagesConstants.HttpErrorGettingEpisodes);
            return StatusCode(
                StatusCodes.Status502BadGateway,
                new { error = MessagesConstants.PruebaTecnicaCarsalesBackEndConnectionError });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MessagesConstants.ErrorGettingEpisodes);
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { error = MessagesConstants.InternalServerError });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EpisodeModel>> GetEpisode(int id)
    {
        try
        {
            _logger.LogInformation(
                MessagesConstants.GetEpisodeLog,
                id);

            var result = await _service.GetEpisodeByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(
                ex,
                MessagesConstants.HttpErrorGettingEpisode,
                id);

            return StatusCode(
                StatusCodes.Status502BadGateway,
                new { error = MessagesConstants.PruebaTecnicaCarsalesBackEndConnectionError });
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                MessagesConstants.ErrorGettingEpisode,
                id);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { error = MessagesConstants.InternalServerError });
        }
    }
}
