using System;
using System.Collections.Generic;

namespace WizardWorldApi.Tests.Integrations.Extensions {
    public static class RandomExtensions {
        public static T GetRandomFromList<T>(this Random random, IList<T> list) {
            return list[random.Next(list.Count - 1)];
        }
    }
}