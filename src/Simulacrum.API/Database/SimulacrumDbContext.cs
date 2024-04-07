using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simulacrum.API.Database.Models;

namespace Simulacrum.API.Database;

public class SimulacrumDbContext(DbContextOptions<SimulacrumDbContext> options) : IdentityDbContext<User, Role, int>(options) { }
