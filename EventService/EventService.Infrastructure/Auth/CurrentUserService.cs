using Microsoft.AspNetCore.Http;
using EventService.Application.Constants;
using EventService.Application.Interfaces;

namespace EventService.Infrastructure.Auth;

public class CurrentUserService: ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.UserId)?.Value;
            return Guid.TryParse(userId, out Guid id) ? id : Guid.Empty;
        }
    }
}