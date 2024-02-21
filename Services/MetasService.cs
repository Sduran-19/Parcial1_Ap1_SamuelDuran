using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_SamuelDuran.Models;
using Parcial1_Ap1_SamuelDuran.DAL;
using System.Linq.Expressions;

namespace Parcial1_Ap1_SamuelDuran.Services;

public class MetasService
{
	private readonly Context _context;

	public MetasService(Context context)
	{
		_context = context;
	}

	public async Task<bool> Crear(Metas Meta)
	{
		if (!await Existe(Meta.MetaId))
			return await Insertar(Meta);
		else
			return await Modificar(Meta);
	}

	public async Task<bool> Insertar(Metas Meta)
	{
		_context.Metas.Add(Meta);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Metas Meta)
	{
		_context.Update(Meta);
		var modifico = await _context.SaveChangesAsync() > 0;
		_context.Entry(Meta).State = EntityState.Detached;
		return modifico;
	}

	private async Task<bool> Existe(int MetaId)
	{
		return await _context.Metas
			.AnyAsync(c => c.MetaId == MetaId);
	}

	public async Task<bool> Eliminar(Metas Meta)
	{
		var cantidad = await _context.Metas
            .Where(c => c.MetaId == Meta.MetaId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Metas?> BuscarMeta(int MetaId)
	{
		return await _context.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.MetaId.ToString() == MetaId.ToString());
	}

	public async Task<Metas?> BuscarId(int MetaId)
	{
		return await _context.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.MetaId == MetaId);
	}

	public async Task<Metas?> BuscarDescripcion(string Descripcion)
	{
		return await _context.Metas
            .AsNoTracking()
			.FirstOrDefaultAsync(c => c.Descripcion == Descripcion);
	}

	public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
	{
		return await _context.Metas
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
