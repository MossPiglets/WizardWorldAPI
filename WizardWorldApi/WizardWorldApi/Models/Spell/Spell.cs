using System;

namespace WizardWorldApi.Models.Spell {
	public class Spell {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Effect { get; set; }
		public bool CanBeVerbal { get; set; }
		public SpellType Type { get; set; }
		public SpellLight Light { get; set; }
		public string Creator { get; set; }
	}
}