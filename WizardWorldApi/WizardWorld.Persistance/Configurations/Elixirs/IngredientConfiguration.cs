using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Persistance.Configurations.Elixirs {
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient> {
        public void Configure(EntityTypeBuilder<Ingredient> builder) {
            builder.HasKey(a => a.Id);
        }
    }
}