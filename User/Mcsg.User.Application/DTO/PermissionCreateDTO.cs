namespace DTO
{
    public class PermissionCreateDTO
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Resource { get; set; }
        public int RoleId { get; set; }
    }
}
