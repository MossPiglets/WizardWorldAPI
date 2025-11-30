using System;
using System.Collections.Generic;

namespace WizardWorld.Application.Requests.Houses {
    public class HouseDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HouseColours { get; set; }
        public string Founder { get; set; }
        public string Animal { get; set; }
        public string Element { get; set; }
        public string Ghost { get; set; }
        public string CommonRoom { get; set; }
        public ICollection<HouseHeadDto> Heads { get; set; }
        public ICollection<TraitDto> Traits { get; set; }
    }
}
