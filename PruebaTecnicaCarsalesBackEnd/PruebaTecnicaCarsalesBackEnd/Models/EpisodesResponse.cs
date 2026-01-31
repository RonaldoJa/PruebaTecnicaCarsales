namespace PruebaTecnicaCarsalesBackEnd.Models
{
    public class EpisodesResponse
    {
        public PageInfo Info { get; set; } = new();
        public List<EpisodeModel> Results { get; set; } = new();
    }
}
