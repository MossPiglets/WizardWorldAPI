using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Persistance {
    public class ApplicationDbContext : DbContext {
        public DbSet<Spell> Spells { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Spell>()
                .HasKey(a => a.Id);
        }
    }
}