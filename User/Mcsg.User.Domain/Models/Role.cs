using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string? RoleName { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<User> Us { get; set; } = new List<User>();
}
