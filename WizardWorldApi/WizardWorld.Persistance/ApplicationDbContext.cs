using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Houses;
using WizardWorld.Persistance.Models.Ingredients;
using WizardWorld.Persistance.Models.Spells;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Persistance {
    public class ApplicationDbContext : DbContext {
        public DbSet<Spell> Spells { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Elixir> Elixirs { get; set; }
        public DbSet<Wizard> Wizards { get; set; }
        public DbSet<Ingredient> Type { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}