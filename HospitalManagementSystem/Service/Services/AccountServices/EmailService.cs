﻿using Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.AccountServices
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public EmailService(UserManager<AppUser> userManager,
                            IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task RegisterEmail(RegisterDTO registerDTO, string link)
        {
            var emailConfig = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            AppUser appUser = await _userManager.FindByEmailAsync(registerDTO.Email);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfig.Title, emailConfig.From));
            message.To.Add(new MailboxAddress(appUser.Name, appUser.Email));
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

            AppUser user = await _userManager.FindByIdAsync(userId);

            await _userManager.ConfirmEmailAsync(user, token);
        }
    }
}
