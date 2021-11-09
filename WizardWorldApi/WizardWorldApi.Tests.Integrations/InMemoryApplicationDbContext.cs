using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorldApi.Tests.Integrations {
	public class InMemoryApplicationDbContext : DbContext {
		public DbSet<Spell> Spells { get; set; }
		public InMemoryApplicationDbContext(DbContextOptions<InMemoryApplicationDbContext> options) : base(options) { }
	}
}