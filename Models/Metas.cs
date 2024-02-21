using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_SamuelDuran.Models;

public class Metas
{
	[Key]
	public int MetaId { get; set; }

    [Required(ErrorMessage = "Error, debe ingresar una fecha")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Error, debe ingresar una descripcion")]
	public string? Descripcion { get; set; }

	[Range(1, float.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
	public decimal Monto { get; set; }

}
