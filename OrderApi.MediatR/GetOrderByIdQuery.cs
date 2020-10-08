using MediatR;
using Microservices.Core;
using Microsoft.EntityFrameworkCore;
using OrderApi.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.MediatR
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IGenericRepository<Order> _repository;

        public GetOrderByIdQueryHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
