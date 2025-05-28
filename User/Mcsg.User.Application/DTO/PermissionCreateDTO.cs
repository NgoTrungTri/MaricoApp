namespace DTO
{
    public class PermissionCreateDTO
    {
        public string Action { get; set; } = null!;
        public string Resource { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
