using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_SamuelDuran.Models;

namespace Parcial1_Ap1_SamuelDuran.DAL;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

	public DbSet<Metas> Metas { get; set; }
}