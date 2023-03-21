using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Persistance.Configurations {
    public class MagicalCreatureRelationConfiguration : IEntityTypeConfiguration<CreatureRelation> {
        public void Configure(EntityTypeBuilder<CreatureRelation> builder) {
            builder.HasKey(a => a.CreatureId);
            //TODO: czy tu mają być dwie różne konfiguracje?
        }
    }
}
