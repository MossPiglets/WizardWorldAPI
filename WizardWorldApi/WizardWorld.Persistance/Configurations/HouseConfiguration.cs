using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Persistance.Configurations {
    public class HouseConfiguration : IEntityTypeConfiguration<House> {
        public void Configure(EntityTypeBuilder<House> builder) {
            builder.HasMany(h => h.Traits);
            builder.HasMany(h => h.Heads);
            builder.HasKey(a => a.Id);
        }
    }
}
