using System.Collections.Generic;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorldApi.Tests.Integrations.Data {
    public static class TestData {
        public static List<FeedbackEmail> FeedbackEmails { get; set; } = new List<FeedbackEmail>();
    }
}