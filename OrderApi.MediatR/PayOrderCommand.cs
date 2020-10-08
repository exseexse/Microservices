using MediatR;
using Microservices.Core;
using OrderApi.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.MediatR
{
    public class PayOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, Order>
    {
        private readonly IGenericRepository<Order> _repository;

        public PayOrderCommandHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Order);
        }
    }
}
