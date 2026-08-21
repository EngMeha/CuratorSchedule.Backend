using System.Text.Json.Serialization;

namespace EventService.Application.Dtos;

public class ResultsDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("place")]
    public PlaceDto? Place { get; set; }

    [JsonPropertyName("categories")] 
    public List<string> Categories { get; set; } = [];
    
    [JsonPropertyName("price")] 
    public string Price { get; set; } = string.Empty;
    
    [JsonPropertyName("is_free")]
    public bool IsFree { get; set; }
    
    [JsonPropertyName("site_url")]
    public string SiteUrl { get; set; } = string.Empty;
    
    [JsonPropertyName("dates")] 
    public List<DatesDto> Dates { get; set; } = [];
}