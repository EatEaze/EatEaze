#pragma warning disable CS8618

namespace EatEaze.Responce
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid UserRoleId { get; set; }
    }
}
