using pubsubapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubapi.Persistqnce
{
   public interface IOrderRepository
    {
        public Task<Orders> GetOrderAsync(Guid id);
        public Task RegisterOrder(Orders order);
    }
}
