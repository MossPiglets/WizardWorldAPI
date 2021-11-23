using System;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Application.Requests.Houses {
    class TraitDto {
        public Guid Id { get; set; }
        public TraitName Name { get; set; }
    }
}
