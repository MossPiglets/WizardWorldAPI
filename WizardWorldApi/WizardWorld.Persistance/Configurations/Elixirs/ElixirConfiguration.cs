using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Persistance.Configurations.Elixirs {
    public class ElixirConfiguration : IEntityTypeConfiguration<Elixir> {
        public void Configure(EntityTypeBuilder<Elixir> builder) {
            builder
                .HasKey(a => a.Id);
            builder
                .HasMany(a => a.Inventors)
                .WithMany(w => w.Elixirs)
                .UsingEntity(e => e.ToTable("WizardsElixirs"));
            builder
                .HasMany(a => a.Ingredients)
                .WithMany(i => i.Elixirs)
                .UsingEntity(e => e.ToTable("ElixirsIngredients"));
        }
    }
}