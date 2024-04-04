using Microsoft.EntityFrameworkCore;
using Simulacrum.API.Database.Models;

namespace Simulacrum.API.Database;

public class SimulacrumDbContext(DbContextOptions<SimulacrumDbContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
}
