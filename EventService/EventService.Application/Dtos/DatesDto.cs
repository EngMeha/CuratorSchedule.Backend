using System.Text.Json.Serialization;

namespace EventService.Application.Dtos;

public class DatesDto
{
    [JsonPropertyName("start_date")]
    public DateOnly? StartDate { get; set; }

    [JsonPropertyName("start_time")]
    public TimeOnly? StartTime { get; set; }
    
    [JsonPropertyName("end_date")]
    public DateOnly? EndDate { get; set; }
    
    [JsonPropertyName("end_time")]
    public TimeOnly? EndTime { get; set; }

    [JsonPropertyName("is_continuous")]
    public bool IsContinuous { get; set; }
    
    [JsonPropertyName("is_endless")]
    public bool IsEndless { get; set; }
    
    [JsonPropertyName("is_startless")]
    public bool IsStartless { get; set; }

    [JsonPropertyName("schedules")]
    public List<SchedulesDto> Schedules { get; set; } = [];
}