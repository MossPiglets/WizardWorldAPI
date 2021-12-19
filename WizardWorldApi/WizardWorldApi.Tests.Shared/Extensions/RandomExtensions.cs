using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardWorldApi.Tests.Shared.Extensions {
    public static class RandomExtensions {
        public static T Choice<T>(this Random random, IEnumerable<T> collection) {
            return collection.ElementAt(random.Next(collection.ToList().Count - 1));
        }
    }
}