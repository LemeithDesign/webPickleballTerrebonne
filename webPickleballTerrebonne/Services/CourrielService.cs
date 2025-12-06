using SendGrid;
using SendGrid.Helpers.Mail;

namespace webPickleballTerrebonne.Services
{
    public class CourrielService(IConfiguration configuration)
    {

        private readonly string? _apiKey = configuration["SendGrid:ApiKey"];

        public async Task<Response> EnvoyerCourrielAsync(string destinataire, string sujet, string contenu)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new InvalidOperationException("La clé API SendGrid n'est pas configurée.");
            }
            SendGridClient client = new(_apiKey);
            EmailAddress from = new("lemeith@hotmail.com", "Pickleball Terrebonne");
            EmailAddress to = new(destinataire);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, sujet, contenu, contenu);
            return await client.SendEmailAsync(msg);
        }
    }
}
