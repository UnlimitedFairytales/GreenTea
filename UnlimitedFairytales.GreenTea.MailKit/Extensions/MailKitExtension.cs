using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace UnlimitedFairytales.GreenTea.MailKit.Extensions
{
    public static class MailKitExtension
    {
        public static readonly int NonePort = 25;
        public static readonly int StartTlsPort = 587;
        public static readonly int SmtpsPort = 465;

        /// <summary>
        /// smtpTlsOption=SecureSocketOptions.StartTlsWhenAvailableにするとSTARTTLS非対応時に平文送信を許容しますが非推奨です。
        /// </summary>
        /// <param name="client"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="toList"></param>
        /// <param name="ccList"></param>
        /// <param name="bccList"></param>
        /// <param name="smtpUri"></param>
        /// <param name="smtpUserId"></param>
        /// <param name="smtpUserPassword"></param>
        /// <param name="smtpTlsOption"></param>
        /// <param name="smtpPort"></param>
        public static void ConnectAndSendPlainMail(
            this SmtpClient client,
            string subject,
            string text,
            string from,
            string[] toList,
            string[] ccList,
            string[] bccList,
            string smtpUri,
            string? smtpUserId = null,
            string? smtpUserPassword = null,
            SecureSocketOptions smtpTlsOption = SecureSocketOptions.StartTls,
            int? smtpPort = null)
        {
            // message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(from, from));
            foreach (var to in toList.Where(to => !string.IsNullOrWhiteSpace(to)))
            {
                message.To.Add(new MailboxAddress(to, to));
            }
            foreach (var cc in ccList.Where(cc => !string.IsNullOrWhiteSpace(cc)))
            {
                message.Cc.Add(new MailboxAddress(cc, cc));
            }
            foreach (var bcc in bccList.Where(bcc => !string.IsNullOrWhiteSpace(bcc)))
            {
                message.Bcc.Add(new MailboxAddress(bcc, bcc));
            }
            message.Subject = subject; // 特にBase64を明示的に指定しなくても適切に送信される模様
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = text };

            // port
            int port = smtpPort ?? (
                smtpTlsOption == SecureSocketOptions.None ? MailKitExtension.NonePort :
                smtpTlsOption == SecureSocketOptions.SslOnConnect ? MailKitExtension.SmtpsPort :
                MailKitExtension.StartTlsPort);

            // connect & send
            client.Connect(smtpUri, port, smtpTlsOption);
            if (smtpUserId != null && smtpUserPassword != null)
            {
                client.Authenticate(smtpUserId, smtpUserPassword);
            }
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
