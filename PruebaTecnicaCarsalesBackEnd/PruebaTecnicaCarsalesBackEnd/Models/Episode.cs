using System.Text.Json.Serialization;

namespace PruebaTecnicaCarsalesBackEnd.Models;

public class EpisodeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("air_date")]
    public string AirDate { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty;
    public List<string> Characters { get; set; } = new();
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
}

