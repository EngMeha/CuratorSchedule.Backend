namespace GroupService.Controllers.Requests;

public record AddEventToGroupRequest(Guid EventId, int CountStudents);