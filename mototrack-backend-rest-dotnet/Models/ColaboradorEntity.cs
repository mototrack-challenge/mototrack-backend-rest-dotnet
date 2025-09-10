using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mototrack_backend_rest_dotnet.Models;

[Table("MT_COLABORADORES")]
public class ColaboradorEntity
{
    [Key]
    [Column("ID_COLABORADOR")]
    public long Id { get; set; }

    [Required]
    [Column("NOME", TypeName = "varchar2(100)")]
    public string Nome { get; set; }

    [Required]
    [Column("MATRICULA", TypeName = "varchar2(20)")]
    public string Matricula { get; set; }

    [Column("EMAIL", TypeName = "varchar2(100)")]
    public string Email { get; set; }
}
