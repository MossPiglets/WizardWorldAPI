﻿using System;
using System.Collections.Generic;

namespace WizardWorld.Application.Requests.Wizards {
    public class WizardDto {
        public ICollection<WizardElixirDto> Elixirs { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}