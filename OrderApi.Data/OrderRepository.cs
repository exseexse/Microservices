using Microservices.Core;
using Microsoft.EntityFrameworkCore;
using OrderApi.DataAccess;
using OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data
{
    public interface IOrderApiRepository : IGenericRepository<Order>
    {     
    }

    public class OrderApiRepository : GenericRepository<Order, OrderDbContext>,
                                    IOrderApiRepository
    {
        public OrderApiRepository(OrderDbContext context)
            : base(context)
        {

        }

        public override async Task<Order> GetByIdAsync(int Id)
        {
            var gettingItem = await _context.Orders.
                SingleAsync(f => f.Id == Id);
            return gettingItem;
        }


       
    }
}
