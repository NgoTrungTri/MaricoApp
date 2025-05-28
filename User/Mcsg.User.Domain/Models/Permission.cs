using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionId { get; set; }

    [StringLength(50)]
    public string? Action { get; set; }

    [StringLength(50)]
    public string? Resource { get; set; }

    public int? RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Permissions")]
    public virtual Role? Role { get; set; }
}
