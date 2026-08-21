using System.Text.Json.Serialization;

namespace EventService.Application.Dtos;

public class SchedulesDto
{
    [JsonPropertyName("days_of_week")] 
    public List<int> DaysOfWeek { get; set; } = [];
    
    [JsonPropertyName("start_time")]
    public TimeOnly? StartTime { get; set; }
    
    [JsonPropertyName("end_time")] 
    public TimeOnly? EndTime { get; set; }
}