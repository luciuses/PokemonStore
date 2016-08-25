using System.Net;
using System.Net.Mail;
using System.Text;

namespace PokemonStore.Web.Components
{
    public interface ISendMailProvider
    {
        bool Send(string mailToAddress, string bodyText);
    }

    /// <summary>
    /// The forms send mail provider.
    /// </summary>
    public class SendMailProvider : ISendMailProvider
    {
        /// <summary>
        /// The email settings.
        /// </summary>
        private readonly IEmailSettingsProvider emailSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMailProvider"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        public SendMailProvider(IEmailSettingsProvider settings)
        {
            emailSettings = settings;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="mailToAddress">
        /// The mail to address.
        /// </param>
        /// <param name="bodyText">
        /// The body text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Send(string mailToAddress, string bodyText)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                var mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, 
                    // From
                    mailToAddress, 
                    // To
                    "Pokemon store message!", 
                    // Subject
                    bodyText); // Body

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }

            return true;
        }
    }
}