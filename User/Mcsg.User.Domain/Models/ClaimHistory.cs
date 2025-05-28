using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("ClaimHistory")]
public partial class ClaimHistory
{
    [Column("coId")]
    public long CoId { get; set; }

    public short AcId { get; set; }

    [Column("coDescription")]
    public string CoDescription { get; set; } = null!;

    public int UsId { get; set; }

    [Column("coActionDate", TypeName = "datetime")]
    public DateTime CoActionDate { get; set; }

    [Key]
    public int Id { get; set; }
}
