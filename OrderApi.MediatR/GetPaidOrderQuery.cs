using MediatR;
using Microservices.Core;
using Microsoft.EntityFrameworkCore;
using OrderApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.MediatR
{
    public class GetPaidOrderQuery : IRequest<List<Order>>
    {
    }
    public class GetPaidOrderQueryHandler : IRequestHandler<GetPaidOrderQuery, List<Order>>
    {
        private readonly IGenericRepository<Order> _repository;

        public GetPaidOrderQueryHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> Handle(GetPaidOrderQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().Where(x => x.OrderState == 2).ToListAsync(cancellationToken);
        }
    }
}
