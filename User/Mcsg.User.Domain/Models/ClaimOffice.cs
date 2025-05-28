using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("ClaimOffice")]
public partial class ClaimOffice
{
    [Key]
    [Column("coId")]
    public long CoId { get; set; }

    [Column("coNo")]
    [StringLength(100)]
    public string? CoNo { get; set; }

    [Column("coImplementer")]
    public int CoImplementer { get; set; }

    public short MkId { get; set; }

    [Column("coAdvance", TypeName = "decimal(18, 5)")]
    public decimal CoAdvance { get; set; }

    [Column("coDescription")]
    public string? CoDescription { get; set; }

    [Column("trId")]
    [StringLength(1024)]
    public string? TrId { get; set; }

    [Column("trNo")]
    [StringLength(3072)]
    public string? TrNo { get; set; }

    [Column("coTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? CoTotalAmount { get; set; }

    [Column("coCreateDate", TypeName = "datetime")]
    public DateTime CoCreateDate { get; set; }

    [Column("coCreator")]
    public int CoCreator { get; set; }

    [Column("coModifyDate", TypeName = "datetime")]
    public DateTime? CoModifyDate { get; set; }

    [Column("coModifier")]
    public int? CoModifier { get; set; }

    public short SttId { get; set; }

    [Column("coDateApprove")]
    public DateOnly? CoDateApprove { get; set; }

    [Column("coDuedate")]
    public DateOnly? CoDuedate { get; set; }

    [Column("coPaymentcycle")]
    public DateOnly? CoPaymentcycle { get; set; }
}
