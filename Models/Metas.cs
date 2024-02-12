using System.ComponentModel.DataAnnotations;
namespace Parcial1_Ap1_SamuelDuran.Models;

public class Metas
{
	[Key]
	public int MetaId { get; set; }

	[Required(ErrorMessage = "Error, debe ingresar una descripcion")]
	public string? Descripcion { get; set; }

	[Required(ErrorMessage = "Error, debe ingresar un monto ")]
	public int? Monto { get; set; }

}
