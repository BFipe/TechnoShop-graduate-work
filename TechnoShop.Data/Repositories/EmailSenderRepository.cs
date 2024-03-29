﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoShop.Data.Repositories.Interfaces;
using TechnoShop.Entities.EmailSenderEntity;

namespace TechnoShop.Data.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailSenderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<EmailSender>> GetEmailSenders()
        {
            return _dbContext.EmailSenders.ToListAsync();
        }

        public Task<EmailSender> GetEmailSenderByName(string email)
        {
            return _dbContext.EmailSenders.SingleOrDefaultAsync(q => q.Email == email);
        }

        public async Task AddEmailSender(string email, string password)
        {
            EmailSender emailSender = new()
            {
                EmailSenderId = Guid.NewGuid().ToString(),
                Email = email,
                Password = password
            };

            await _dbContext.EmailSenders.AddAsync(emailSender);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmailSender> GetEmailSender()
        {
            return await _dbContext.EmailSenders.FirstOrDefaultAsync();
        }

        public async Task DeleteEmailSender(string email)
        {
            _dbContext.EmailSenders.Remove(await _dbContext.EmailSenders.SingleOrDefaultAsync(q => q.Email == email));
        }
    }
}
