using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace WizardWorld.Application.Services.EmailProviders;

public sealed class MailgunEmailProvider : IEmailProvider
{
    private readonly IConfiguration _config;

    public MailgunEmailProvider(IConfiguration config)
    {
        _config = config;
    }

    public async Task<EmailResult> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail)
    {
        var apiKey = _config.GetValue<string>("WizardWorldApiEmailKey");
        var options = new RestClientOptions("https://api.mailgun.net")
        {
            Authenticator = new HttpBasicAuthenticator("api", apiKey),
        };
        var client = new RestClient(options);
        var request = new RestRequest("/v3/sandbox372fd37a430445af9e6a03437c72236d.mailgun.org/messages", Method.Post);
        request.AlwaysMultipartFormData = true;
        request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox372fd37a430445af9e6a03437c72236d.mailgun.org>");
        request.AddParameter("to", "Moss Piglets <truemosspiglets@gmail.com>");
        request.AddParameter("subject", "Feedback");
        request.AddParameter("text",
            $"""
            Hi Piglets!
            You have feedback:

            Type: {feedbackEmail.FeedbackType}
            Id: {feedbackEmail.EntityId}
            Content: 
            {feedbackEmail.Feedback}
            """);
        var result = await client.ExecuteAsync(request);
        return new EmailResult()
        {
            IsSuccess = result.IsSuccessful,
        };
    }
}