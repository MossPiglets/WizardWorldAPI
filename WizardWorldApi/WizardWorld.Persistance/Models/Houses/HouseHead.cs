using System;

namespace WizardWorld.Persistance.Models.Houses {
    public class HouseHead {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid HouseId { get; set; }
    }
}
