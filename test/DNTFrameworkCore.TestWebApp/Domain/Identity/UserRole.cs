using DNTFrameworkCore.Domain;

namespace DNTFrameworkCore.TestWebApp.Domain.Identity
{
    public class UserRole : TrackableEntity<long>, IHasRowIntegrity, ICreationTracking
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public long RoleId { get; set; }
    }
}