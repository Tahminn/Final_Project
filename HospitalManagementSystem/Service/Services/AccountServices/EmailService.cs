using Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;
using Service.Services.Interfaces;

namespace Service.Services.AccountServices
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public EmailService(UserManager<User> userManager,
                            IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task RegisterEmail(RegisterDTO registerDTO, string link)
        {
            var emailConfig = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            User user = await _userManager.FindByEmailAsync(registerDTO.Email);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfig.Title, emailConfig.From));
            message.To.Add(new MailboxAddress(user.Name, user.Email));
            message.Subject = emailConfig.Subject;
            string emailbody = link;
            message.Body = new TextPart() { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect(emailConfig.SmtpServer, emailConfig.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailConfig.Username, emailConfig.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        public async Task ConfirmEmail(string userId, string token)
        {

            User user = await _userManager.FindByIdAsync(userId);

            await _userManager.ConfirmEmailAsync(user, token);
        }
    }
}
