using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Persistance.Configurations.MagicalCreatures {
    public class MagicalCreatureRelationConfiguration : IEntityTypeConfiguration<CreatureRelation> {
        public void Configure(EntityTypeBuilder<CreatureRelation> builder) {
            builder.HasKey(a => new
            {
                a.CreatureId, 
                a.RelatedCreatureId
            } );
        }
    }
}
