using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Persistance.Configurations {
    public class HouseConfiguration : IEntityTypeConfiguration<House> {
        public void Configure(EntityTypeBuilder<House> builder) {
            builder
                .HasKey(a => a.Id);
        }
    }
}
