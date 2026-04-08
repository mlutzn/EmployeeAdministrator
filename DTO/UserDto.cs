namespace DTO
{
    public class UserDto : BaseClass
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}