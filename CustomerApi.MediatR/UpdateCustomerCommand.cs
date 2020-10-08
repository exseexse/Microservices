using CustomerApi.Model;
using CustomerApi.RabbitMq;
using MediatR;
using Microservices.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.MediatR
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {  
        public Customer Customer { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IGenericRepository<Customer> _repository;
        private readonly ICustomerUpdateSender _customerUpdateSender;

        public UpdateCustomerCommandHandler(IGenericRepository<Customer> repository, ICustomerUpdateSender customerUpdateSender)
        {
            _repository = repository;
            _customerUpdateSender = customerUpdateSender;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.UpdateAsync(request.Customer);
            _customerUpdateSender.SendCustomer(customer);
            return customer;
        }
    }
}
