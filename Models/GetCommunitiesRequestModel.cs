using System.Text.Json.Serialization;

namespace Reddit.Models
{
    public class GetCommunitiesRequestModel
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_ascending")]
        public bool? IsAscending { get; set; }

        [JsonPropertyName("sort_key")]
        public string? SortKey { get; set; }

        [JsonPropertyName("search_key")]
        public string? SearchKey { get; set; }
    }
}
