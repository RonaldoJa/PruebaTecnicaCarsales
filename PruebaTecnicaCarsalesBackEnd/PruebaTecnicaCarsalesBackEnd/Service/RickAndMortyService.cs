using System.Text.Json;
using PruebaTecnicaCarsalesBackEnd.Constants;
using PruebaTecnicaCarsalesBackEnd.Models;

namespace PruebaTecnicaCarsalesBackEnd.Services;

public class RickAndMortyService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RickAndMortyService> _logger;
    private readonly string _baseUrl;

    public RickAndMortyService(
        HttpClient httpClient,
        ILogger<RickAndMortyService> logger,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _baseUrl = configuration[ConfigurationKeys.BaseUrl]
            ?? throw new InvalidOperationException(
                $"{ConfigurationKeys.BaseUrl} no está configurado");
    }

    public async Task<EpisodesResponse?> GetEpisodesAsync(
        int page = 1,
        string? name = null,
        string? episode = null)
    {
        try
        {
            var url = BuildUrl(page, name, episode);
            _logger.LogInformation(MessagesConstants.FetchingEpisodes, url);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EpisodesResponse>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MessagesConstants.ErrorFetchingEpisodes);
            throw;
        }
    }

    public async Task<EpisodeModel?> GetEpisodeByIdAsync(int id)
    {
        try
        {
            var url = $"{_baseUrl}/{id}";
            _logger.LogInformation(MessagesConstants.FetchingEpisode, url);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EpisodeModel>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MessagesConstants.ErrorFetchingEpisode, id);
            throw;
        }
    }

    private string BuildUrl(int page, string? name, string? episode)
    {
        var query = $"?{QueryParameters.Page}={page}";

        if (!string.IsNullOrWhiteSpace(name))
            query += $"&{QueryParameters.Name}={Uri.EscapeDataString(name)}";

        if (!string.IsNullOrWhiteSpace(episode))
            query += $"&{QueryParameters.Episode}={Uri.EscapeDataString(episode)}";

        return $"{_baseUrl}{query}";
    }
}

