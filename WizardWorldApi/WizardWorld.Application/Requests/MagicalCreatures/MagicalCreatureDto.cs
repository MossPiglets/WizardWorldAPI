using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Application.Requests.MagicalCreatures {
    public class MagicalCreatureDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CreatureClassificationByMinistryOfMagic Classification { get; set; }
        public CreatureStatus Status { get; set; }
        public CreatureDangerousnessLevel DangerousnessLevel { get; set; }
        public ICollection<string> CreatureRelations { get; set; }
        public string NativeTo { get; set; }
    }
}
