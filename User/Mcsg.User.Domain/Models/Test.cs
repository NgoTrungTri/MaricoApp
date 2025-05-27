using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Test")]
public partial class Test
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("test")]
    [StringLength(500)]
    public string? Test1 { get; set; }

    [Column("test1")]
    [StringLength(500)]
    public string? Test11 { get; set; }

    [Column("test2")]
    [StringLength(500)]
    public string? Test2 { get; set; }
}
