using System.Text.Json.Serialization;

namespace EventService.Application.Dtos;

public class PlaceDto
{
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
}