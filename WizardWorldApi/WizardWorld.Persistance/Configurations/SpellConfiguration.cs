using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Persistance.Configurations {
    public class SpellConfiguration : IEntityTypeConfiguration<Spell> {
        public void Configure(EntityTypeBuilder<Spell> builder) {
            builder
                .HasKey(a => a.Id);
        }
    }
}