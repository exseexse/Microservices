using System;
using MediatR;
using Microservices.Core;
using OrderApi.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.MediatR
{
    public class GetOrderByCustomerIdQuery : IRequest<List<Order>>
    {
        public int CustomerId { get; set; }
    }
    public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, List<Order>>
    {
        private readonly IGenericRepository<Order> _repository;

        public GetOrderByCustomerIdQueryHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> Handle(GetOrderByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().Where(x => x.CustomerId == request.CustomerId).ToListAsync(cancellationToken);
        }
    }
}
