using Microsoft.EntityFrameworkCore;
using pubsubapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubapi.Persistqnce
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {

        }

        public DbSet<Orders> Ordersdemo { get; set; }

    }
}
