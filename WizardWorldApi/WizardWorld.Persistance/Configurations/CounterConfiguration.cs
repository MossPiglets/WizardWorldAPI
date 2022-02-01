using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizardWorld.Persistance.Models.Counters;

namespace WizardWorld.Persistance.Configurations {
    public class CounterConfiguration : IEntityTypeConfiguration<Counter> {
        public void Configure(EntityTypeBuilder<Counter> builder) {
            builder.HasKey(a => a.Id);
        }
    }
}