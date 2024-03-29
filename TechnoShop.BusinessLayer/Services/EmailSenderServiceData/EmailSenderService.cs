﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using TechnoShop.BusinessLayer.Interfaces;
using TechnoShop.Data.Repositories;
using TechnoShop.Data.Repositories.Interfaces;
using TechnoShop.Exceptions;

namespace TechnoShop.BusinessLayer.Services.EmailSenderServiceData
{
    public class EmailSenderService : IEmailSenderService, IDisposable
    {
        private MimeMessage _message;
        private BodyBuilder _bodyBuilder;
        private SmtpClient _smtpClient;
        private readonly IEmailSenderRepository _emailSenderRepository;

        public EmailSenderService(IEmailSenderRepository emailSenderRepository)
        {
            _emailSenderRepository = emailSenderRepository;
            _message = new MimeMessage();
            _bodyBuilder = new BodyBuilder();

            var emailSender = _emailSenderRepository.GetEmailSender().Result;
            if (emailSender == null) return;

            _smtpClient = new SmtpClient();
            _smtpClient.Connect("smtp.gmail.com", 465, true);
            _smtpClient.Authenticate(emailSender.Email, emailSender.Password);
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (_smtpClient == null) return Task.CompletedTask;

            MailboxAddress from = new MailboxAddress("TechnoShop", "TechnoShopEmailSender@gmail.com");
            MailboxAddress to = new MailboxAddress($"{email}", $"{email}");
            _message.From.Add(from);
            _message.To.Add(to);

            _message.Subject = subject;
            _bodyBuilder.HtmlBody = htmlMessage;
            _message.Body = _bodyBuilder.ToMessageBody();

            return _smtpClient.SendAsync(_message);
        }

        public async Task<List<string>> GetEmailSenders()
        {
            var senders = await _emailSenderRepository.GetEmailSenders();
            List<string> result = new List<string>();
            senders.ForEach(q =>
            {
                result.Add(q.Email);
            });
            return result;
        }

        public async Task AddEmailSender(string email, string password)
        {
            if (await _emailSenderRepository.GetEmailSenderByName(email) != null)
            {
                throw new ObjectExistsException(email);
            }
            await _emailSenderRepository.AddEmailSender(email, password);
            await _emailSenderRepository.SaveChanges();
        }

        public async Task DeleteEmailSender(string email)
        {
            if (await _emailSenderRepository.GetEmailSenderByName(email) != null)
            {
                await _emailSenderRepository.DeleteEmailSender(email);
                await _emailSenderRepository.SaveChanges();
            }
            else throw new ObjectNotExistsException(email);
        }

        public void Dispose()
        {
            if (_smtpClient != null)
            {
                _smtpClient.Disconnect(true);
                _smtpClient.Dispose();
            }
        }

    }
}