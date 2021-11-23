using System;

namespace WizardWorld.Persistance.Models.Spells {
    public class Spell {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Incantation { get; set; }
        public string Effect { get; set; }
        public bool? CanBeVerbal { get; set; }
        public SpellType Type { get; set; }
        public SpellLight Light { get; set; }
        public string Creator { get; set; }
    }
}