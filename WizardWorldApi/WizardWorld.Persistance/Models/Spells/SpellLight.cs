using System.ComponentModel;

namespace WizardWorld.Persistance.Models.Spells {
    public enum SpellLight {
        None = 0,
        Blue = 1,
        [Description("Icy blue")]
        IcyBlue = 2,
        Red = 3,
    }
}