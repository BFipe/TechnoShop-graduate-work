﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoShop.Data.Repositories.Interfaces;
using TechnoShop.Entities.UserOrderEntity;

namespace TechnoShop.Data.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ManagerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserOrder> OrderById(string orderId)
        { 
            return await _dbContext.UserOrders.Include(q => q.UserOrderProducts).ThenInclude(q => q.Product).SingleOrDefaultAsync(q => q.UserOrderId == orderId);
        }

        public async Task<List<UserOrder>> GetOrders()
        {
            return await _dbContext.UserOrders
                .Include(q => q.TechnoShopUser)
                .Include(q => q.UserOrderProducts)
                .ThenInclude(q => q.Product)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(string orderId)
        {
            var order = await _dbContext.UserOrders.SingleOrDefaultAsync(q => q.UserOrderId == orderId);
            _dbContext.UserOrders.Remove(order);
        }
    }
}
