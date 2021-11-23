using System;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application.Requests.Spells {
    public class SpellDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Incantation { get; set; }
        public string Effect { get; set; }
        public bool CanBeVerbal { get; set; }
        public SpellType Type { get; set; }
        public SpellLight Light { get; set; }
        public string Creator { get; set; }
    }
}