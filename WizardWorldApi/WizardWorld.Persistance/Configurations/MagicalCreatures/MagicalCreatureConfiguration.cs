using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Persistance.Configurations.MagicalCreatures {
    public class MagicalCreatureConfiguration : IEntityTypeConfiguration<MagicalCreature> {
        public void Configure(EntityTypeBuilder<MagicalCreature> builder) {
            builder.HasKey(a => a.Id);
            builder.HasMany(h => h.CreatureRelations).WithOne().HasForeignKey(t => t.CreatureId); 
        }
    }
}
