using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mototrack_backend_rest_dotnet.Models.Enums;


namespace mototrack_backend_rest_dotnet.Models;

[Table("MT_MOTOS")]
public class MotoEntity
{
    [Key]
    [Column("id_moto")]
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo Placa é obrigatorio!")]
    [StringLength(7, ErrorMessage = "A Placa deve conter exatamente 7 caracteres.")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O campo Chassi é obrigatorio!")]
    [StringLength(17, ErrorMessage = "O Chassi deve conter exatamente 17 caracteres.")]
    public string Chassi { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatorio!")]
    [Column(TypeName = "varchar(11)")]
    public ModeloMoto Modelo { get; set; }

    [Required(ErrorMessage = "O campo Status é obrigatorio!")]
    [Column(TypeName = "varchar(30)")]
    public StatusMoto Status { get; set; }
}
