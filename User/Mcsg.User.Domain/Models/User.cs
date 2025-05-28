using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class User
{
    [Key]
    public int UsId { get; set; }

    [StringLength(500)]
    public string UsName { get; set; } = null!;

    [StringLength(500)]
    public string UsFullName { get; set; } = null!;

    [StringLength(500)]
    public string UsMail { get; set; } = null!;

    [StringLength(500)]
    public string? UsN1 { get; set; }

    [StringLength(500)]
    public string? UsN2 { get; set; }

    [StringLength(500)]
    public string? UsN3 { get; set; }

    [StringLength(500)]
    public string? UsManager { get; set; }

    [Column("UsSManager")]
    [StringLength(500)]
    public string? UsSmanager { get; set; }

    [StringLength(500)]
    public string? UsDirector { get; set; }

    [StringLength(500)]
    public string? UsVp { get; set; }

    [StringLength(500)]
    public string? UsCoo { get; set; }

    public short? DmId { get; set; }

    public short? GrId { get; set; }

    public bool UsIsActive { get; set; }

    [StringLength(500)]
    public string? UsSignatureUrl { get; set; }

    public short? PosId { get; set; }

    [StringLength(100)]
    public string? UsSapCode { get; set; }

    public bool? UsAutoUpdate { get; set; }

    public bool? UsIsManager { get; set; }

    [Column("UsIsSManager")]
    public bool? UsIsSmanager { get; set; }

    public bool? UsIsDirector { get; set; }

    [Column("UsIsVP")]
    public bool? UsIsVp { get; set; }

    [Column("UsIsCOO")]
    public bool? UsIsCoo { get; set; }

    [Column("UsN1Name")]
    [StringLength(500)]
    public string? UsN1name { get; set; }

    [Column("UsN2Name")]
    [StringLength(500)]
    public string? UsN2name { get; set; }

    [Column("UsN3Name")]
    [StringLength(500)]
    public string? UsN3name { get; set; }

    public bool? UsisAdmin { get; set; }

    [StringLength(200)]
    public string? UsJob { get; set; }

    public short? UsOrder { get; set; }

    [StringLength(500)]
    public string? UsDepartmentAd { get; set; }

    public DateOnly? UsCreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("UsId")]
    [InverseProperty("Us")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
