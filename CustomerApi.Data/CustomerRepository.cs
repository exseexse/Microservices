using CustomerApi.DataAccess;
using CustomerApi.Model;
using Microservices.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerApi.Data
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        void RemovePhoneNumber(PhoneNumber model);
    }

    public class CustomerRepository : GenericRepository<Customer, CustomerDbContext>,
                                    ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context)
            : base(context)
        {

        }

        public override async Task<Customer> GetByIdAsync(int Id)
        {
            var gettingItem = await _context.Customers.
                Include(f => f.PhoneNumbers).
                SingleAsync(f => f.Id == Id);
            return gettingItem;
        }


        public void RemovePhoneNumber(PhoneNumber model)
        {
            _context.PhoneNumbers.Remove(model);
        }
    }
}
