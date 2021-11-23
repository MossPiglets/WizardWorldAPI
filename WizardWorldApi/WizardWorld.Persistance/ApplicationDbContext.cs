using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance.Models.Houses;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Persistance {
    public class ApplicationDbContext : DbContext {
        public DbSet<Spell> Spells { get; set; }
        public DbSet<House> Houses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}