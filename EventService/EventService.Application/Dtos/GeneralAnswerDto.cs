using System.Text.Json.Serialization;

namespace EventService.Application.Dtos;

public class GeneralAnswerDto
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    
    [JsonPropertyName("next")] 
    public string Next { get; set; } = string.Empty;
    
    [JsonPropertyName("previous")]
    public string Previous { get; set; } = string.Empty;
    
    [JsonPropertyName("results")] 
    public List<ResultsDto> Results { get; set; } = [];
}