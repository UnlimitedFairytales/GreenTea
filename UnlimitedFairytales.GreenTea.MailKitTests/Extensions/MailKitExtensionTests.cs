using MailKit.Net.Smtp;
using MailKit.Security;
using Xunit;

namespace UnlimitedFairytales.GreenTea.MailKit.Extensions.Tests
{
    public class MailKitExtensionTests
    {
        [Fact()]
        public void ConnectAndSendPlainMailTest()
        {
            // Arrange
            var client = new SmtpClient();
            // Act
            using (client)
            {
                client.ConnectAndSendPlainMail(
                    "これは件名です①",
                    "ここは本文です。",
                    "etherealgarden@msn.com",
                    new string[] { "kondo.mamoru@realsys.co.jp" },
                    new string[] { "etherealgarden@msn.com" },
                    new string[] { },
                    "smtp-mail.outlook.com",
                    "********",
                    "********");
                client.ConnectAndSendPlainMail(
                    "これは件名です②",
                    "ここは本文です。",
                    "etherealgarden@msn.com",
                    new string[] { "etherealgarden@msn.com" },
                    new string[] { },
                    new string[] { "kondo.mamoru@realsys.co.jp" },
                    "smtp-mail.outlook.com",
                    "********",
                    "********",
                    SecureSocketOptions.StartTlsWhenAvailable,
                    587);
            }
            // Assert
            // メールが送信されたことも確認する
            Assert.True(true);
        }
    }
}