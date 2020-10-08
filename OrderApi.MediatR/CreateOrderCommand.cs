using MediatR;
using Microservices.Core;
using OrderApi.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.MediatR
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IGenericRepository<Order> _repository;

        public CreateOrderCommandHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Order);
        }
    }
}
