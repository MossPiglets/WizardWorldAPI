using System;

namespace WizardWorld.Persistance.Models.MagicalCreatures {
    public class CreatureRelation {
        public Guid CreatureId { get; set; }
        public Guid RelatedCreatureId { get; set; }
    }
}
