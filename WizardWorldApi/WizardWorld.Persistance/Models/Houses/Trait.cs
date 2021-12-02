using System;

namespace WizardWorld.Persistance.Models.Houses {
    public class Trait {
		public Guid Id { get; set; }
		public TraitName Name { get; set; }
		public Guid HouseId { get; set; }
	}

}
