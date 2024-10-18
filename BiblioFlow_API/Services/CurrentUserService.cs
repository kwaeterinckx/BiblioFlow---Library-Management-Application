using System.Security.Claims;

namespace BiblioFlow_API.Services
{
    public interface ICurrentUserRepository
    {
        Guid UserId { get; }
    }

    public class CurrentUserService : ICurrentUserRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid UserId
        {
            get
            {
                string? userId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId is null) return Guid.Empty;

                return Guid.Parse(userId);
            }
        }
    }
}
