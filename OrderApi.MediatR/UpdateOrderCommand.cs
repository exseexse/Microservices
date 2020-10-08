using MediatR;
using Microservices.Core;
using OrderApi.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.MediatR
{
    public class UpdateOrderCommand : IRequest
    {
        public List<Order> Orders { get; set; }
    }
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IGenericRepository<Order> _repository;

        public UpdateOrderCommandHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateRangeAsync(request.Orders);
            return Unit.Value;
        }
    }
}
