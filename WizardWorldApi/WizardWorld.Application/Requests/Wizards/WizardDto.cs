﻿using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Application.Requests.Wizards {
    public class WizardDto {
        public ICollection<Elixir> Elixirs { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}