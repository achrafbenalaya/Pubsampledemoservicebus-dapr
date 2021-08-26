using Microsoft.EntityFrameworkCore;
using pubsubapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubapi.Persistqnce
{
    public class OrdersRepository : IOrderRepository
    {

        private readonly OrdersContext _context;

        public OrdersRepository(OrdersContext context)
        {
            _context = context;
        }

        public async Task<Orders> GetOrderAsync(Guid id)
        {
            return await _context.Ordersdemo
              .FirstOrDefaultAsync(c => c.OrderId == id);
        }

        public async Task RegisterOrder(Orders order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
