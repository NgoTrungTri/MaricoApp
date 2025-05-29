using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class UserRole
{
    [Key]
    public int UsId { get; set; }

    [Key]
    public int RoleId { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UsId")]
    [InverseProperty("UserRoles")]
    public virtual User User { get; set; } = null!;
}
