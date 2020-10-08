using CustomerApi.Model;
using MediatR;
using Microservices.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.MediatR
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IGenericRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Customer);       
        }
    }
}
