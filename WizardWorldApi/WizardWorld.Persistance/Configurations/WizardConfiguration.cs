using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Persistance.Configurations {
    public class WizardConfiguration : IEntityTypeConfiguration<Wizard> {
        public void Configure(EntityTypeBuilder<Wizard> builder) {
            builder.HasKey(a => a.Id);
        }
    }
}