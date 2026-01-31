namespace PruebaTecnicaCarsalesBackEnd.Constants
{
    public class MessagesConstants
    {
        public const string GetEpisodesLog = "GET episodes - Page: {Page}, Name: {Name}, Episode: {Episode}";

        public const string GetEpisodeLog = "GET episode {Id}";

        public const string HttpErrorGettingEpisodes = "HTTP error getting episodes";

        public const string HttpErrorGettingEpisode = "HTTP error getting episode {Id}";

        public const string ErrorGettingEpisodes = "Error getting episodes";

        public const string ErrorGettingEpisode = "Error getting episode {Id}";

        public const string PruebaTecnicaCarsalesBackEndConnectionError = "Error connecting to Rick and Morty API";

        public const string InternalServerError = "Internal server error";

        public const string FetchingEpisodes = "Fetching episodes from: {Url}";

        public const string FetchingEpisode = "Fetching episode from: {Url}";

        public const string ErrorFetchingEpisodes = "Error fetching episodes";

        public const string ErrorFetchingEpisode = "Error fetching episode {Id}";
    }
}
